using EcommerceApp.Shared.DTOs;
using X.PagedList;

namespace EcommerceApp.Domain.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<bool> AddAsync(ProductDto productDto);
        

        Task<IPagedList<ProductDto>> SearchProductsAsync(int pageNumber, int pageSize, string searchQuery, string sortBy);
    }
}
