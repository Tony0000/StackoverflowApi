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
            services.AddDbContext<OverflowDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OverflowDb")));

            services.AddScoped<IOverflowDbContext>(provider => provider.GetService<OverflowDbContext>());

            return services;
        }
    }
}