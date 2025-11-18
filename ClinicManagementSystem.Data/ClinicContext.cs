using ClinicManagementSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClinicManagementSystem.Data
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Leaves> Leaves { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Time_Slots> Time_Slots { get; set; }
        public DbSet<Patient_Encounter> Patient_Encounters { get; set; }
        public DbSet<Observations> Observations { get; set; }
        public DbSet<MedicalReports> MedicalReports { get; set; }
        public DbSet<Prescriptions> Prescriptions { get; set; }
        public DbSet<Patient_Queue> Patient_Queues { get; set; }
        public DbSet<Bill_Templates> Bill_Templates { get; set; }
        public DbSet<Patient_Bills> Patient_Bills { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Notification_Templates> Notification_Templates { get; set; }
        public DbSet<Patient_Notifications> Patient_Notifications { get; set; }
        public DbSet<Audit_Log> Audit_Logs { get; set; }
        public DbSet<User_Sessions> User_Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.Name).HasMaxLength(225).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.Password).HasMaxLength(255);
                entity.HasOne(e => e.Role)
                      .WithMany(r => r.Users)
                      .HasForeignKey(e => e.RoleID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleID);
                entity.Property(e => e.RoleName).HasMaxLength(100);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DoctorID);
                entity.Property(e => e.Specialization).HasMaxLength(255);
                entity.Property(e => e.Qualification).HasMaxLength(255);
                entity.HasOne(d => d.User)
                      .WithOne()
                      .HasForeignKey<Doctor>(d => d.DoctorID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Leaves>(entity =>
            {
                entity.HasKey(e => e.LeaveID);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Leaves)
                      .HasForeignKey(e => e.UserID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Patient_ID);
                entity.Property(e => e.Address).HasMaxLength(450);
                entity.Property(e => e.Blood_Group).HasMaxLength(6);
                entity.Property(e => e.Sex).HasMaxLength(1);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.AppointmentID);
                entity.HasOne(a => a.Patient)
                      .WithMany(p => p.Appointments)
                      .HasForeignKey(a => a.PatientID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Doctor)
                      .WithMany(d => d.Appointments)
                      .HasForeignKey(a => a.DoctorID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Slot)
                      .WithMany()
                      .HasForeignKey(a => a.SlotID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.CreatedUser)
                      .WithMany()
                      .HasForeignKey(a => a.CreatedBy)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Time_Slots>(entity =>
            {
                entity.HasKey(e => e.SlotID);
                entity.HasOne(e => e.Doctor)
                      .WithMany()
                      .HasForeignKey(e => e.DoctorID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Patient_Encounter>(entity =>
            {
                entity.HasKey(e => e.Encounter_id);
                entity.HasOne(e => e.Patient)
                      .WithMany(p => p.Encounters)
                      .HasForeignKey(e => e.Patient_id)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Doctor)
                      .WithMany(d => d.Encounters)
                      .HasForeignKey(e => e.DoctorID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Appointment)
                      .WithMany()
                      .HasForeignKey(e => e.AppointmentID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Patient_Encounter>()
                      .WithMany()
                      .HasForeignKey(e => e.Parent_Encounter_id)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Observations>(entity =>
            {
                entity.HasKey(e => e.ObservationId);
                entity.HasOne(e => e.Encounter)
                      .WithMany(e => e.Observations)
                      .HasForeignKey(e => e.Encounter_Id)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Staff)
                      .WithMany()
                      .HasForeignKey(e => e.Staff_id)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<MedicalReports>(entity =>
            {
                entity.HasKey(e => e.ReportId);
                entity.HasOne(e => e.Patient)
                      .WithMany()
                      .HasForeignKey(e => e.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Encounter)
                      .WithMany(e => e.MedicalReports)
                      .HasForeignKey(e => e.EncounterId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Prescriptions>(entity =>
            {
                entity.HasKey(e => e.PrescriptionId);
                entity.HasOne(e => e.Encounter)
                      .WithMany(e => e.Prescriptions)
                      .HasForeignKey(e => e.EncounterId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Doctor)
                      .WithMany()
                      .HasForeignKey(e => e.DoctorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Patient_Queue>(entity =>
            {
                entity.HasKey(e => e.QueueId);
                entity.HasOne(e => e.Appointment)
                      .WithMany()
                      .HasForeignKey(e => e.AppointmentID);
                entity.HasOne(e => e.Patient)
                      .WithMany()
                      .HasForeignKey(e => e.PatientID);
                entity.HasOne(e => e.Doctor)
                      .WithMany()
                      .HasForeignKey(e => e.DoctorID);
            });

            modelBuilder.Entity<Bill_Templates>(entity =>
            {
                entity.HasKey(e => e.TemplateId);
                entity.Property(e => e.BaseAmount).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Patient_Bills>(entity =>
            {
                entity.HasKey(e => e.BillId);
                entity.Property(e => e.Amount).HasPrecision(10, 2);
                entity.Property(e => e.DiscountAmount).HasPrecision(10, 2);
                entity.Property(e => e.FinalAmount).HasPrecision(10, 2);

                entity.HasOne(e => e.Patient)
                      .WithMany()
                      .HasForeignKey(e => e.PatientID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Encounter)
                      .WithMany(e => e.Bills)
                      .HasForeignKey(e => e.EncounterID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Template)
                      .WithMany(t => t.Bills)
                      .HasForeignKey(e => e.TemplateId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Doctor)
                      .WithMany()
                      .HasForeignKey(e => e.DoctorID)
                      .OnDelete(DeleteBehavior.Restrict); 

                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(e => e.CreatedBy)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);
                entity.Property(e => e.TotalAmount).HasPrecision(10, 2);
                entity.Property(e => e.PaidAmount).HasPrecision(10, 2);
                entity.Property(e => e.BalanceAmount).HasPrecision(10, 2);

                entity.HasOne(e => e.Patient)
                      .WithMany()
                      .HasForeignKey(e => e.PatientID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Bill)
                      .WithMany()
                      .HasForeignKey(e => e.BillId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Notification_Templates>(entity =>
            {
                entity.HasKey(e => e.TemplateId);
            });

            modelBuilder.Entity<Patient_Notifications>(entity =>
            {
                entity.HasKey(e => e.NotificationId);
                entity.HasOne(e => e.Patient)
                      .WithMany()
                      .HasForeignKey(e => e.PatientID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Template)
                      .WithMany(t => t.Notifications)
                      .HasForeignKey(e => e.TemplateId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Creator)
                      .WithMany()
                      .HasForeignKey(e => e.CreatedBy)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Audit_Log>(entity =>
            {
                entity.HasKey(e => e.AuditId);
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserID)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Patient)
                      .WithMany()
                      .HasForeignKey(e => e.PatientID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User_Sessions>(entity =>
            {
                entity.HasKey(e => e.SessionId);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Sessions)
                      .HasForeignKey(e => e.UserID)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
