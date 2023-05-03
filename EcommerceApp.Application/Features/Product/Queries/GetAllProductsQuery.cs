using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Shared.DTOs;
using MediatR;

namespace EcommerceApp.Application.Features.Product.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductService _productService;

        public GetAllProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllAsync();
            return products;
        }
    }

}
