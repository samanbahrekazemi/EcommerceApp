using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Shared.DTOs;
using MediatR;
using X.PagedList;

namespace EcommerceApp.Application.Features.Product.Queries
{
    public class SearchProductsQuery : IRequest<IPagedList<ProductDto>>
    {
        public string SearchQuery { get; set; } = string.Empty;
        public string SortBy { get; set; } = "date_desc";
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }



    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, IPagedList<ProductDto>>
    {
        private readonly IProductService _productService;

        public SearchProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IPagedList<ProductDto>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productService.SearchProductsAsync(request.PageNumber, request.PageSize, request.SearchQuery, request.SortBy);
        }
    }

}
