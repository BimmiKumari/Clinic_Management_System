using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Models
{
    public class Invoice
    {
        public Guid InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public Guid PatientID { get; set; }
        public Guid BillId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; } = 0;
        public decimal BalanceAmount { get; set; }
        public string PaymentStatus { get; set; } = "Unpaid";
        public DateTime? PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; }


        public Patient Patient { get; set; }
        public Patient_Bills Bill { get; set; }
    }
}
