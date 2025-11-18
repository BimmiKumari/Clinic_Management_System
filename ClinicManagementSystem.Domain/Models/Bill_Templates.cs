using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Models
{
    public class Bill_Templates
    {
        public Guid TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal BaseAmount { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public ICollection<Patient_Bills> Bills { get; set; }
    }
}
