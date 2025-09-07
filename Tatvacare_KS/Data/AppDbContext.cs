using Microsoft.EntityFrameworkCore;
using Tatvacare_KS.Model;

namespace Tatvacare_KS.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
