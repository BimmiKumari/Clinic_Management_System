using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Models
{
    public class Doctor
    {
        public Guid DoctorID { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public int YearOfExperience { get; set; }
        public string WorkingDays { get; set; }
        public TimeSpan StartTime { get; set; } = new TimeSpan(9, 0, 0);
        public TimeSpan EndTime { get; set; } = new TimeSpan(18, 0, 0);
        public int SlotDuration { get; set; } = 30;
        public TimeSpan? BreakStartTime { get; set; }
        public TimeSpan? BreakEndTime { get; set; }


        public User User { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Patient_Encounter> Encounters { get; set; }
    }
}
