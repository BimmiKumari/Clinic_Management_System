using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Models
{
    public class Patient_Encounter
    {
        public Guid Encounter_id { get; set; }
        public Guid Patient_id { get; set; }
        public Guid DoctorID { get; set; }
        public DateTime Encounter_date { get; set; }
        public string Encounter_type { get; set; }
        public string Reason_description { get; set; }
        public string Description { get; set; }
        public Guid? Parent_Encounter_id { get; set; }
        public Guid AppointmentID { get; set; }


        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Appointment Appointment { get; set; }
        public ICollection<Observations> Observations { get; set; }
        public ICollection<MedicalReports> MedicalReports { get; set; }
        public ICollection<Prescriptions> Prescriptions { get; set; }
        public ICollection<Patient_Bills> Bills { get; set; }
    }
}
