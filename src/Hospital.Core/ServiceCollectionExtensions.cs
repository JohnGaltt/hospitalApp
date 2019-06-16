using Hospital.Core.BusinessLogic;
using Hospital.Core.BusinessLogic.Managers;
using Hospital.Core.BusinessLogic.Managers.Abstractions;
using Hospital.Core.DataAccess;
using Hospital.Core.DataAccess.Extensions;
using Hospital.Core.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCustomSwagger("Hospital API");
            services.AddApplicationDbContext<HospitalDbContext>(configuration.GetSection("Database").Get<DatabaseSettings>());

            services.AddTransient<IDoctorsManager, DoctorsManager>();
            services.AddTransient<IPatientsManager, PatientsManager>();
            services.AddTransient<IPatientSummariesManager, PatientSummariesManager>();

            return services;
        }
    }
}
