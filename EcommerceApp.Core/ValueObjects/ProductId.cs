namespace EcommerceApp.Domain.ValueObjects
{
    public class ProductId : Id<ProductId>
    {
        public int Value { get; set; }
        public ProductId(int value)
        {
            Value = value;
        }


        public static implicit operator int(ProductId giftId) => giftId.Value;

        public static implicit operator ProductId(int giftId) => new(giftId);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
