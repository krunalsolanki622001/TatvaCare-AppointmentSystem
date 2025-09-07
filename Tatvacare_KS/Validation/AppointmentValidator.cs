using Tatvacare_KS.Model;

namespace Tatvacare_KS.Validation
{
    public static class AppointmentValidator
    {
        public static (bool ok, string? error) Validate(Appointment a)
        {
            if (a.StartTime == default || a.EndTime == default)
            {
                return (false, "StartTime and EndTime are required.");
            }

            if (a.EndTime <= a.StartTime)
            {
                return (false, "EndTime must be after StartTime.");
            }

            if (string.IsNullOrWhiteSpace(a.PatientName))
            {
                return (false, "PatientName is required.");
            }

            if (string.IsNullOrWhiteSpace(a.DoctorName))
            {
                return (false, "DoctorName is required.");
            }

            return (true, null);
        }
    }
}
