namespace EcommerceApp.Domain.ValueObjects
{
    public class CategoryId : Id<CategoryId>
    {
        public int Value { get; set; }
        public CategoryId(int value)
        {
            Value = value;
        }


        public static implicit operator int(CategoryId giftId) => giftId.Value;

        public static implicit operator CategoryId(int giftId) => new(giftId);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
