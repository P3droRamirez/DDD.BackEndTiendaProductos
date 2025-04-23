using DDD.BackEndTiendaProductos.Domain.Models;
using MediatR;

namespace DDD.BackEndTiendaProductos.Application.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest<OkResponseModel>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }

    }
}
