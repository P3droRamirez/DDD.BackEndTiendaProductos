using DDD.BackEndTiendaProductos.Domain.Models;
using MediatR;

namespace DDD.BackEndTiendaProductos.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<OkResponseModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public CreateProductCommand(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }

}
