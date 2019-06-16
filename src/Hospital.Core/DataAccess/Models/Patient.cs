using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Hospital.Core.DataAccess.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<PatientSummary> PatientSummaries { get; set; }

        public static void Build(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Patient> entityTypeBuilder = modelBuilder.Entity<Patient>();
            entityTypeBuilder.ToTable("patients");
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(32);
        }
    }
}
