using AutoMapper;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Shared.DTOs;
using EcommerceApp.Shared.Models;
using MediatR;

namespace EcommerceApp.Application.Features.Product.Commands
{
    public class UpdateProductCommand : IRequest<Result<ProductDto?>>
    {
        public int Id { get; set; }
        public ProductDto ProductDto { get; set; }
    }



    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<ProductDto?>>
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<Result<ProductDto?>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            ProductDto productDto = _mapper.Map<ProductDto>(request);
            return await _productService.UpdateAsync(productDto);
        }
    }
}
