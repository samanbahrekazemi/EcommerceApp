using EcommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EcommerceApp.Domain.ValueObjects;

namespace EcommerceApp.Infrastructure.Persistence.Configs
{
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(g => g.Id).HasConversion(id => id.Value, value => new TagId(value));

            builder.Property(p => p.Name)
                .HasMaxLength(120)
                .IsRequired();

            builder.HasMany(p => p.ProductTags)
                .WithOne(t => t.Tag)
                .HasForeignKey(t => t.TagId);
        }
    }
}
