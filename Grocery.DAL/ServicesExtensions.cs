using System;
using System.Collections.Generic;
using Grocery.DAL.Interfaces;
using Grocery.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;





namespace Grocery.DAL
{

    public static class ServicesExtensions
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => { options.UseSqlServer(connectionString); },
                ServiceLifetime.Transient
            );

            services.AddScoped<ApplicationDbContext>();
            return services;
        }
    }
}