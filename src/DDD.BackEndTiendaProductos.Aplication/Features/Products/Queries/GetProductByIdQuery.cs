using DDD.BackEndTiendaProductos.Domain.Models;
using MediatR;

namespace DDD.BackEndTiendaProductos.Application.Features.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductResponseModel?>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }


}
