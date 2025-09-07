using System.ComponentModel.DataAnnotations;

namespace Tatvacare_KS.Model
{
    public class Appointment
    {
        public int Id { get; set; }


        [Required, StringLength(100)]
        public string PatientName { get; set; } = default!;


        [Required]
        public DateTime StartTime { get; set; }


        [Required]
        public DateTime EndTime { get; set; }


        [Required, StringLength(100)]
        public string DoctorName { get; set; } = default!;
    }
}
