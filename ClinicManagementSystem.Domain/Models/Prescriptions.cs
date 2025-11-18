using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Models
{
    public class Prescriptions
    {
        public Guid PrescriptionId { get; set; }
        public Guid EncounterId { get; set; }
        public Guid DoctorId { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public string Notes { get; set; }


        public Patient_Encounter Encounter { get; set; }
        public Doctor Doctor { get; set; }
    }
}
