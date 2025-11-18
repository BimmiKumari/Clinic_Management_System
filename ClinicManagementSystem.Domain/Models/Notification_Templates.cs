using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Models
{
    public class Notification_Templates
    {
        public Guid TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public string NotificationType { get; set; }
        public string TriggerEvent { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public ICollection<Patient_Notifications> Notifications { get; set; }
    }
}
