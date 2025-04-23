
using DDD.BackEndTiendaProductos.Business.Services;
using DDD.BackEndTiendaProductos.Domain.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.BackEndTiendaProductos.Business.Registration
{
    public static class BusinessRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IProductServices, ProductService>();

            return services;
        }
    }
}
