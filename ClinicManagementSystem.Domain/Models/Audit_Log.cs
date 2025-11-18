using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Models
{
    public class Audit_Log
    {
        public Guid AuditId { get; set; }
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public Guid? RecordId { get; set; }
        public string ActionDescription { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string IPAddress { get; set; }
        public string UserAgent { get; set; }
        public string SessionId { get; set; }
        public Guid? PatientID { get; set; }
        public string ActionResult { get; set; } = "Success";
        public string ErrorMessage { get; set; }
        public DateTime ActionTimestamp { get; set; }
        public DateTime ServerTimestamp { get; set; }


        public User User { get; set; }
        public Patient Patient { get; set; }
    }
}
