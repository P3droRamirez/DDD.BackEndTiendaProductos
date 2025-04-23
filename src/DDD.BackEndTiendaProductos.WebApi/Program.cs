using DDD.BackEndTiendaProductos.Application.Registration;
using DDD.BackEndTiendaProductos.Infrastructure.Registration;
using DDD.BackEndTiendaProductos.Business.Registration;
using DDD.BackEndTiendaProductos.WebApi.Builders;
using DDD.BackEndTiendaProductos.Application.Features.Validators;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using DDD.BackEndTiendaProductos.Application.Mappings;

namespace DDD.BackEndTiendaProductos.WebApi.Registration;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //Registrar Automapper
        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

        // Registro de servicios (directorios 'Registration')
        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddBusinessServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddSwaggerServices();

        builder.Services.AddFluentValidation(conf =>
            conf.RegisterValidatorsFromAssemblyContaining<ProductModelValidator>());

        builder.Services.AddFluentValidationRulesToSwagger();

        builder.Services.AddControllers();

        var app = builder.Build();

        

        app.AddSwaggerApp();

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
