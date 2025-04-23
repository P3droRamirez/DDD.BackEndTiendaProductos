using System.Diagnostics.CodeAnalysis;
using DDD.BackEndTiendaProductos.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace DDD.BackEndTiendaProductos.WebApi.Controllers.Swagger
{
    [ExcludeFromCodeCoverage]
    public class ProductModelExample : IExamplesProvider<ProductModel>
    {
        public ProductModel GetExamples()
        {
           return new ProductModel
           {
               Name = "Iphone 17 Pro Max Azul Marino",
               Price = 899.99M,
               Stock = 10
           };
        }
    }
}
