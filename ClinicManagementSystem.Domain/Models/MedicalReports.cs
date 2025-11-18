using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Models
{
    public class MedicalReports
    {
        public Guid ReportId { get; set; }
        public Guid PatientId { get; set; }
        public Guid EncounterId { get; set; }
        public string FileUrl { get; set; }
        public string ReportType { get; set; }
        public string Findings { get; set; }
        public Guid UploadedBy { get; set; }
        public DateTime DateUploaded { get; set; }


        public Patient Patient { get; set; }
        public Patient_Encounter Encounter { get; set; }
        public User Uploader { get; set; }
    }
}
