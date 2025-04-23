using DDD.BackEndTiendaProductos.Domain.Models;
using FluentValidation;

namespace DDD.BackEndTiendaProductos.Application.Features.Validators
{
    public class ProductModelValidator : AbstractValidator<ProductModel>
    {
        public ProductModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .Length(2, 50).WithMessage("El nombre del producto debe tener entre 2 y 50 caracteres.");
            RuleFor(x => x.Stock)
                .GreaterThan(0).WithMessage("El stock del producto debe ser mayor que cero.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("El precio del producto debe ser mayor que cero.");
        }
    }

}
