using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceApp.Infrastructure.Persistence.Configs
{
    public class ProductTagConfig : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.TagId });

            builder.Property(g => g.ProductId).HasConversion(id => id.Value, value => new ProductId(value));
            builder.Property(g => g.TagId).HasConversion(id => id.Value, value => new TagId(value));
        }
    }
}
