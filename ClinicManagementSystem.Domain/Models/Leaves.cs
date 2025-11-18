using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Models
{
    public class Leaves
    {
        public Guid LeaveID { get; set; }
        public Guid UserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime LeaveApplied { get; set; }
        public bool IsFullDay { get; set; } = true;


        public User User { get; set; }
    }
}
