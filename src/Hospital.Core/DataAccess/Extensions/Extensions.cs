using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Hospital.Core.DataAccess.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationDbContext<TContext>(this IServiceCollection services, DatabaseSettings databaseSettings, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
            where TContext : DbContext
        {
            if (databaseSettings == null)
            {
                throw new ArgumentNullException(nameof(databaseSettings));
            }

            services
                .AddSingleton(Options.Create(databaseSettings))
                .AddEntityFrameworkNpgsql()
                .AddDbContext<TContext>(serviceLifetime);

            return services;
        }

    }
}
