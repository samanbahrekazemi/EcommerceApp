using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace EcommerceApp.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : Repository<Product, ProductId>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await DbSet.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public IQueryable<Product> Querable()
        {
            return DbSet
                .Include(c => c.Category)
                .Include(t => t.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .AsQueryable();
        }

    }
}
