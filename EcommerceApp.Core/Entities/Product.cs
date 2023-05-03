using EcommerceApp.Domain.ValueObjects;

namespace EcommerceApp.Domain.Entities
{
    public class Product : BaseEntity<ProductId>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }
        public CategoryId CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}
