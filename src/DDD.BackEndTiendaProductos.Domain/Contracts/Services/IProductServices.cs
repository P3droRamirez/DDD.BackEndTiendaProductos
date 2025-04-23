using DDD.BackEndTiendaProductos.Domain.Models;

namespace DDD.BackEndTiendaProductos.Domain.Contracts.Services
{
    public interface  IProductServices
    {
        Task<ProductResponseModel?> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductResponseModel>> GetAllProductAsync();
        Task<OkResponseModel> AddProductAsync(ProductModel model);
        Task<OkResponseModel?> UpdateProductAsync(ProductModel model, int id);
        Task<OkResponseModel?> DeleteProductAsync(int id);
    }
}
