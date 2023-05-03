using EcommerceApp.Domain.Entities;
using X.PagedList;

namespace EcommerceApp.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);
        IQueryable<Product> Querable();
    }
}
