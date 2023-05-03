using EcommerceApp.Application.Mappings;
using EcommerceApp.Application.Services;
using EcommerceApp.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EcommerceApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            // Add MediatR
            services.AddMediatR(x=> x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Add AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));


            //Services
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
