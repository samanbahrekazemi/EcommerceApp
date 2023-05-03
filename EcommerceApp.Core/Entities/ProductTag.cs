using EcommerceApp.Domain.ValueObjects;

namespace EcommerceApp.Domain.Entities
{
    public class ProductTag
    {
        public ProductId ProductId { get; set; }
        public Product Product { get; set; }
        public TagId TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
