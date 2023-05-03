namespace EcommerceApp.Domain.ValueObjects
{
    public class UserId : Id<UserId>
    {
        public int Value { get; set; }
        public UserId(int value)
        {
            Value = value;
        }


        public static implicit operator int(UserId giftId) => giftId.Value;

        public static implicit operator UserId(int giftId) => new(giftId);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
