using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductFlow.OnionTest.Server.Application.Behaviors;
using ProductFlow.OnionTest.Server.Application.Mappings.Category;
using ProductFlow.OnionTest.Server.Application.Mappings.Product;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ProductMapping>();
                cfg.AddProfile<CategoryMapping>();
            });
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
