using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Core.DataAccess.Models
{
    public class PatientSummary
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Conclusion { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        public static void Build(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<PatientSummary> entityTypeBuilder = modelBuilder.Entity<PatientSummary>();
            entityTypeBuilder.ToTable("patientsummaries");
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Conclusion).IsRequired().HasMaxLength(128);
            entityTypeBuilder.HasOne(x => x.Doctor).WithMany().HasForeignKey(x => x.DoctorId);
            entityTypeBuilder.HasOne(x => x.Patient).WithMany().HasForeignKey(x => x.PatientId);
        }
    }
}
