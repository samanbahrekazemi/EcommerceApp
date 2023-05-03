namespace EcommerceApp.Domain.ValueObjects
{
    public class TagId : Id<TagId>
    {
        public int Value { get; set; }
        public TagId(int value)
        {
            Value = value;
        }


        public static implicit operator int(TagId giftId) => giftId.Value;

        public static implicit operator TagId(int giftId) => new(giftId);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
