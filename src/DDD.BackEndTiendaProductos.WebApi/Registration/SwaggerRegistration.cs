
using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace DDD.BackEndTiendaProductos.WebApi.Registration
{
    public static class SwaggerRegistration
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            var enabled = Application.Registration.ConfigurationManager.SwaggerEnabled;

            if (enabled)
            {
                services.AddEndpointsApiExplorer();
                services.AddSwaggerGen(c =>
                {
                    c.ExampleFilters();
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Products API",
                        Description = "Simple ASP.NET Core Web Api para Crud de productos",
                        Contact = new OpenApiContact
                        {
                            Name = "Pedro Ramirez Gonzalez",
                            Email = "pedroramirez_1991@hotmail.com",
                            Url = new Uri("https://github.com/P3droRamirez_"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        },
                    });

                    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
                    if (File.Exists(xmlPath))
                    {
                        c.IncludeXmlComments(xmlPath);
                    }
                    else
                    {
                        Console.WriteLine($"XML documentation file not found: {xmlPath}");
                    }
                });
            }

            return services;
        }
    }
}
