using DDD.BackEndTiendaProductos.Domain.Models;
using MediatR;

namespace DDD.BackEndTiendaProductos.Application.Features.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductResponseModel>>
    {
       
    }
    
}
