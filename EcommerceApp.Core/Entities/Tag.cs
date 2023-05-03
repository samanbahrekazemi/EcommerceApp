using EcommerceApp.Domain.ValueObjects;

namespace EcommerceApp.Domain.Entities
{
    public class Tag : BaseEntity<TagId>
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }

}