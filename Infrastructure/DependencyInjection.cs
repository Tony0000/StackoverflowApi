using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTIONSTRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = configuration.GetConnectionString("DefaultConnection");
            }
            
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<OverflowDbContext>(options =>
                    options.UseNpgsql(connectionString));

            services.AddScoped<IOverflowDbContext>(provider => provider.GetService<OverflowDbContext>());

            return services;
        }
    }
}