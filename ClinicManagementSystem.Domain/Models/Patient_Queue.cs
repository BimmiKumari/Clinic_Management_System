using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Models
{
    public class Patient_Queue
    {
        public Guid QueueId { get; set; }
        public Guid AppointmentID { get; set; }
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }
        public string QueueZone { get; set; }
        public DateTime QueueDate { get; set; }
        public int QueuePosition { get; set; }
        public string Status { get; set; } = "Waiting";
        public DateTime? CheckedInAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public Appointment Appointment { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
