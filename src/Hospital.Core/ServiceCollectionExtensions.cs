using Hospital.Core.BusinessLogic;
using Hospital.Core.BusinessLogic.Managers.Abstractions;
using Hospital.Core.DataAccess;
using Hospital.Core.DataAccess.Extensions;
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
            services.AddApplicationDbContext<HospitalDbContext>(configuration.GetSection("Database").Get<DatabaseSettings>());

            services.AddTransient<IDoctorsManager, DoctorsManager>();

            return services;
        }
    }
}
