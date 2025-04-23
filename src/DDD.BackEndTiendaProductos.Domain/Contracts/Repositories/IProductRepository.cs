using DDD.BackEndTiendaProductos.Domain.Entities;

namespace DDD.BackEndTiendaProductos.Domain.Contracts.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
       Task<Product?> GetProductByName(string name);
    }
}
