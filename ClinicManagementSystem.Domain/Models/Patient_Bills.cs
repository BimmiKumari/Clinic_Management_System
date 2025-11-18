using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Models
{
    public class Patient_Bills
    {
        public Guid BillId { get; set; }
        public Guid PatientID { get; set; }
        public Guid EncounterID { get; set; }
        public Guid TemplateId { get; set; }
        public string BillType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal DiscountAmount { get; set; } = 0;
        public decimal FinalAmount { get; set; }
        public DateTime BillDate { get; set; }
        public Guid DoctorID { get; set; }
        public string Status { get; set; } = "Generated";
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }


        public Patient Patient { get; set; }
        public Patient_Encounter Encounter { get; set; }
        public Bill_Templates Template { get; set; }
        public Doctor Doctor { get; set; }
        public User Creator { get; set; }
    }
}
