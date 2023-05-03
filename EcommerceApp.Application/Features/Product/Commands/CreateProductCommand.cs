using AutoMapper;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Shared.DTOs;
using MediatR;

namespace EcommerceApp.Application.Features.Product.Commands
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        //public List<int> TagIds { get; set; }
    }


    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            ProductDto productDto = _mapper.Map<ProductDto>(request);
            return await _productService.AddAsync(productDto);

        }
    }

}
