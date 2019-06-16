using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Core.DataAccess.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DoorNumber { get; set; }

        public static void Build(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Department> entityTypeBuilder = modelBuilder.Entity<Department>();
            entityTypeBuilder.ToTable("departments");
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(32);
            entityTypeBuilder.Property(x => x.DoorNumber).IsRequired();
        }
    }
}
