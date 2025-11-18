using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Models
{
    public class Patient_Notifications
    {
        public Guid NotificationId { get; set; }
        public Guid PatientID { get; set; }
        public Guid TemplateId { get; set; }
        public string RecipientType { get; set; }
        public Guid RecipientId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string NotificationType { get; set; }
        public string RecipientContact { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime? ScheduledAt { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public DateTime? ReadAt { get; set; }
        public int RetryCount { get; set; } = 0;
        public string ErrorMessage { get; set; }
        public string RelatedEntityType { get; set; }
        public Guid? RelatedEntityId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }


        public Patient Patient { get; set; }
        public Notification_Templates Template { get; set; }
        public User Creator { get; set; }
    }
}
