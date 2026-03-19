using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }  
        public DbSet<Patient> Patients { get; set; }  
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=ContactDoctor;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
            .HasIndex(a => new { a.DoctorId, a.AppointmentDate, a.AppointmentTime })
            .IsUnique();
        }
    }
}
