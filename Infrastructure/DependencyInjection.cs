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
            Console.WriteLine($"From env: {connectionString}");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = configuration.GetConnectionString("DefaultConnection");
            }

            Console.WriteLine($"From project: {connectionString}");

            services.AddDbContext<OverflowDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IOverflowDbContext>(provider => provider.GetService<OverflowDbContext>());

            return services;
        }
    }
}