using Hospital.Core.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using System;

namespace Hospital.Core.DataAccess
{
    public class HospitalDbContext : DbContext
    {
        private readonly DatabaseSettings _databaseOptions;

        public HospitalDbContext()
        {

        }
        public HospitalDbContext(IOptions<DatabaseSettings> databaseOptions)
        {
            if (databaseOptions.Value == null)
            {
                throw new ArgumentNullException(nameof(databaseOptions));
            }

            if (string.IsNullOrEmpty(databaseOptions.Value.ConnectionString))
            {
                throw new ArgumentException("Database connection string is null or empty.");
            }

            _databaseOptions = databaseOptions.Value;
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientSummary> PatientSummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ChangeNamesToLowerCase(modelBuilder);
            Doctor.Build(modelBuilder);
            Department.Build(modelBuilder);
            Patient.Build(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_databaseOptions == null)
            {
                optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }
            else
            {
                optionsBuilder.UseNpgsql(_databaseOptions.ConnectionString,
                npgsqlOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: _databaseOptions.MaxRetryCount,
                        maxRetryDelay: TimeSpan.FromSeconds(_databaseOptions.MaxRetryDelay),
                        errorCodesToAdd: null);
                });
            }
        }

        private void ChangeNamesToLowerCase(ModelBuilder modelBuilder)
        {
            foreach (var table in modelBuilder.Model.GetEntityTypes())
            {
                ConvertToLowerCase(table);
                foreach (var property in table.GetProperties())
                {
                    ConvertToLowerCase(property);
                }

                foreach (var primaryKey in table.GetKeys())
                {
                    ConvertToLowerCase(primaryKey);
                }

                foreach (var foreignKey in table.GetForeignKeys())
                {
                    ConvertToLowerCase(foreignKey);
                }

                foreach (var indexKey in table.GetIndexes())
                {
                    ConvertToLowerCase(indexKey);
                }
            }
        }

        private void ConvertToLowerCase(object entity)
        {
            switch (entity)
            {
                case IMutableEntityType table:
                    table.Relational().TableName = table.Relational().TableName.ToLowerInvariant();
                    break;
                case IMutableProperty property:
                    property.Relational().ColumnName = property.Relational().ColumnName.ToLowerInvariant();
                    break;
                case IMutableKey primaryKey:
                    primaryKey.Relational().Name = primaryKey.Relational().Name.ToLowerInvariant();
                    break;
                case IMutableForeignKey foreignKey:
                    foreignKey.Relational().Name = foreignKey.Relational().Name.ToLowerInvariant();
                    break;
                case IMutableIndex indexKey:
                    indexKey.Relational().Name = indexKey.Relational().Name.ToLowerInvariant();
                    break;
                default:
                    throw new NotImplementedException("Unexpected type was provided to snake case converter");
            }
        }
    }
}
