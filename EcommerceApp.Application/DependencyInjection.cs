using EcommerceApp.Application.Mappings;
using EcommerceApp.Application.Services;
using EcommerceApp.Domain.Events.Product;
using EcommerceApp.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace EcommerceApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            // Add MediatR
            services.AddMediatR(x=> x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IMediator, Mediator>();

            // Add Fluent Validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Add AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));


            // Services
            services.AddScoped<IProductService, ProductService>();


            // Handlers


            return services;
        }
    }
}
