using DDD.BackEndTiendaProductos.Domain.Models;
using MediatR;

namespace DDD.BackEndTiendaProductos.Application.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest<OkResponseModel?>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public UpdateProductCommand(int id, string name, decimal price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }
    }

}
