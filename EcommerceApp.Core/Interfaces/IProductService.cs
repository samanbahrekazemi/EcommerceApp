using EcommerceApp.Shared.DTOs;
using EcommerceApp.Shared.Models;
using X.PagedList;

namespace EcommerceApp.Domain.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<IPagedList<ProductDto>> SearchProductsAsync(int pageNumber, int pageSize, string searchQuery, string sortBy);

        Task<Result<ProductDto?>> FindAsync(int id);
        Task<Result<ProductDto?>> AddAsync(ProductDto productDto);
        Task<Result<ProductDto?>> UpdateAsync(ProductDto productDto);
        Task<Result<ProductDto?>> DeleteAsync(int id);
    }
}
