using EcommerceApp.Application.Features.Product.Commands;
using FluentValidation;

namespace EcommerceApp.Application.Features.Product.Validators
{
    public class UpdateCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateCommandValidator(ProductDtoValidator productDtoValidator)
        {
            RuleFor(x => x.ProductDto).SetValidator(new ProductDtoValidator());
        }
    }
}
