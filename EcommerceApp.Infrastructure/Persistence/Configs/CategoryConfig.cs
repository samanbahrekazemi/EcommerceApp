using EcommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EcommerceApp.Domain.ValueObjects;

namespace EcommerceApp.Infrastructure.Persistence.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(g => g.Id).HasConversion(id => id.Value, value => new CategoryId(value));

            builder.Property(p => p.Name)
                .HasMaxLength(120)
                .IsRequired();

            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}
