using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Models
{
    public class Patient
    {
        public Guid Patient_ID { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public char Sex { get; set; }
        public string Address { get; set; }
        public string Blood_Group { get; set; }
        public string Allergies { get; set; }


        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Patient_Encounter> Encounters { get; set; }
    }
}
