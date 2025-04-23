using DDD.BackEndTiendaProductos.Domain.Models;
using DDD.BackEndTiendaProductos.Application.Features.Products.Queries;
using DDD.BackEndTiendaProductos.Domain.Contracts.Services;
using MediatR;
using DDD.BackEndTiendaProductos.Application.Features.Products.Commands;

namespace DDD.BackEndTiendaProductos.Business.Services
{
    public class ProductService : IProductServices
    {
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }


        async Task<ProductResponseModel?> IProductServices.GetProductByIdAsync(int id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllProductAsync()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }

        async Task<OkResponseModel> IProductServices.AddProductAsync(ProductModel model)
        {
            var productCommand = new CreateProductCommand(model.Name, model.Price, model.Stock);
            return await _mediator.Send(productCommand);
        }

        public async Task<OkResponseModel?> UpdateProductAsync(ProductModel model,int id)
        {
            var productCommand = new UpdateProductCommand(id, model.Name, model.Price, model.Stock);
            return await _mediator.Send(productCommand);
        }

        public Task<OkResponseModel?> DeleteProductAsync(int id)
        {
            var productCommand = new DeleteProductCommand(id);
            return _mediator.Send(productCommand);
        }
    }
}
