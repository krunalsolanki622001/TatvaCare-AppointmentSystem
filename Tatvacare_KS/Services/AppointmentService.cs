using Microsoft.EntityFrameworkCore;
using Tatvacare_KS.Data;
using Tatvacare_KS.Model;
using Tatvacare_KS.Validation;

namespace Tatvacare_KS.Services
{
    public class AppointmentService 
    {
        private readonly AppDbContext _db;

        public AppointmentService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<Appointment>> GetAllAsync(CancellationToken ct = default)
        {
            return await _db.Appointments
                .OrderBy(a => a.StartTime)
                .ToListAsync(ct);
        }

        public async Task<Appointment?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _db.Appointments.FindAsync(new object[] { id }, ct);
        }

        public async Task<(bool ok, string? error, Appointment? created)> CreateAsync(Appointment a, CancellationToken ct = default)
        {
            var v = AppointmentValidator.Validate(a);
            if (!v.ok)
            {
                return (false, v.error, null);
            }

            bool overlap = await _db.Appointments.AnyAsync(
                x => x.DoctorName == a.DoctorName &&
                     a.StartTime < x.EndTime &&
                     a.EndTime > x.StartTime,
                ct);

            if (overlap)
            {
                return (false, "Overlapping appointment for this doctor.", null);
            }

            _db.Appointments.Add(a);
            await _db.SaveChangesAsync(ct);
            return (true, null, a);
        }

        public async Task<(bool ok, string? error)> UpdateAsync(int id, Appointment a, CancellationToken ct = default)
        {
            var existing = await _db.Appointments.FindAsync(new object[] { id }, ct);
            if (existing is null)
            {
                return (false, "Appointment not found.");
            }

            var v = AppointmentValidator.Validate(a);
            if (!v.ok)
            {
                return (false, v.error);
            }

            bool overlap = await _db.Appointments.AnyAsync(
                x => x.Id != id &&
                     x.DoctorName == a.DoctorName &&
                     a.StartTime < x.EndTime &&
                     a.EndTime > x.StartTime,
                ct);

            if (overlap)
            {
                return (false, "Overlapping appointment for this doctor.");
            }

            existing.PatientName = a.PatientName;
            existing.StartTime = a.StartTime;
            existing.EndTime = a.EndTime;
            existing.DoctorName = a.DoctorName;

            await _db.SaveChangesAsync(ct);
            return (true, null);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var existing = await _db.Appointments.FindAsync(new object[] { id }, ct);
            if (existing is null)
            {
                return false;
            }

            _db.Appointments.Remove(existing);
            await _db.SaveChangesAsync(ct);
            return true;
        }
    }
}
