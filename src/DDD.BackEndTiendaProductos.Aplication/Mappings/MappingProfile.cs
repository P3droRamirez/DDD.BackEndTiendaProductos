using AutoMapper;
using DDD.BackEndTiendaProductos.Application.Features.Products.Commands;
using DDD.BackEndTiendaProductos.Domain.Entities;
using DDD.BackEndTiendaProductos.Domain.Models;

namespace DDD.BackEndTiendaProductos.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo de Product a ProductResponseModel y viceversa
            CreateMap<Product, ProductResponseModel>()
                .ReverseMap();
            CreateMap<CreateProductCommand, Product>()
                .ReverseMap();
            CreateMap<UpdateProductCommand, Product>()
                .ReverseMap();
        }
    }
}
