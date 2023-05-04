using EcommerceApp.Application.Features.Product.Commands;
using FluentValidation;

namespace EcommerceApp.Application.Features.Product.Validators
{
    public class CreateCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateCommandValidator(ProductDtoValidator productDtoValidator)
        {
            RuleFor(x => x).SetValidator(new ProductDtoValidator());
        }
    }
}
