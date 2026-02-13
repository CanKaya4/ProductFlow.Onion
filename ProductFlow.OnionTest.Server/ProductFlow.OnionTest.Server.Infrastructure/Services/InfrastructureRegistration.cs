using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductFlow.OnionTest.Server.Domain.Interfaces;
using ProductFlow.OnionTest.Server.Infrastructure.Context;
using ProductFlow.OnionTest.Server.Infrastructure.Repositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Infrastructure.Services
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddSingleton<IConnectionMultiplexer>(sp =>
               ConnectionMultiplexer.Connect(configuration.GetSection("Redis:Configuration").Value ?? "localhost:6379"));
            services.AddScoped<ICacheService, RedisCacheService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
           

            return services;
        }
    }
}
