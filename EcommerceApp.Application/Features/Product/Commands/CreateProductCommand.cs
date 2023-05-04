using AutoMapper;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Shared.DTOs;
using EcommerceApp.Shared.Models;
using FluentValidation;
using MediatR;

namespace EcommerceApp.Application.Features.Product.Commands
{
    public class CreateProductCommand : IRequest<Result<ProductDto?>>
    {
        public ProductDto ProductDto { get; set; }
    }


    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductDto?>>
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IValidator<CreateProductCommand> _validator;
        public CreateProductCommandHandler(IMapper mapper, IProductService productService, IValidator<CreateProductCommand> validator)
        {
            _mapper = mapper;
            _productService = productService;
            _validator = validator;
        }

        public async Task<Result<ProductDto?>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Validate the request
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            ProductDto productDto = _mapper.Map<ProductDto>(request);
            return await _productService.AddAsync(productDto);

        }
    }

}
