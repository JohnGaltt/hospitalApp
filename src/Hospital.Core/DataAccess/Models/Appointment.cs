using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Hospital.Core.DataAccess.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public static void Build(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Appointment> entityTypeBuilder = modelBuilder.Entity<Appointment>();
            entityTypeBuilder.ToTable("appointments");
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.CreateDateTime).HasMaxLength(32);
            entityTypeBuilder.HasOne(x => x.Patient).WithMany().HasForeignKey(x => x.PatientId);
        }
    }
}
