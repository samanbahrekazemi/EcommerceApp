using EcommerceApp.Domain.ValueObjects;

namespace EcommerceApp.Domain.Entities
{
    public class Category : BaseEntity<CategoryId>
    {

        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
