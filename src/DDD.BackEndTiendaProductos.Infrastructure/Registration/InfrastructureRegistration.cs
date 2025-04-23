
using DDD.BackEndTiendaProductos.Application.Registration;
using DDD.BackEndTiendaProductos.Domain.Contracts.Repositories;
using DDD.BackEndTiendaProductos.Infrastructure.Data;
using DDD.BackEndTiendaProductos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.BackEndTiendaProductos.Infrastructure.Registration
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConfigurationManager.LocalDB));

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
