using AutoMapper;
using EcommerceApp.Domain.Events.Product;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Shared.DTOs;
using EcommerceApp.Shared.Models;
using FluentValidation;
using MediatR;

namespace EcommerceApp.Application.Features.Product.Commands
{
    public class CreateProductCommand : ProductDto, IRequest<Result<ProductDto?>>
    {

    }


    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductDto?>>
    {
        private readonly IProductService _productService;
        private readonly IValidator<CreateProductCommand> _validator;
        private readonly IMapper _mapper;
        private readonly IEventHandler _eventHandler;
        public CreateProductCommandHandler(IProductService productService, IValidator<CreateProductCommand> validator, IMapper mapper, IEventHandler eventHandler)
        {
            _productService = productService;
            _validator = validator;
            _mapper = mapper;
            _eventHandler = eventHandler;
        }
        public async Task<Result<ProductDto?>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Check Validation
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Create
            var entity = _mapper.Map<ProductDto>(request);
            var result = await _productService.AddAsync(entity);

            // Raise @Event
            var productCreatedEvent = new ProductCreatedEvent() { ProductDto = entity, Description = result.Message };
            await _eventHandler.PublishAsync(productCreatedEvent);

            return result;
        }
    }

}
