using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Core.DataAccess.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string Position { get; set; }

        public Department Department { get; set; }

        public static void Build(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Doctor> entityTypeBuilder = modelBuilder.Entity<Doctor>();
            entityTypeBuilder.ToTable("doctors");
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(32);
            entityTypeBuilder.Property(x => x.Position).IsRequired().HasMaxLength(32);
            entityTypeBuilder.HasOne(x => x.Department).WithMany().HasForeignKey(x => x.DepartmentId);
        }
    }

}
