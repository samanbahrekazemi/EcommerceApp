namespace EcommerceApp.Domain.ValueObjects
{
    public abstract class Id<T> where T : Id<T>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;


            var other = (T)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) => current * 23 + (obj?.GetHashCode() ?? 0));
        }

        public static bool operator ==(Id<T>? left, Id<T>? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Id<T>? left, Id<T>? right)
        {
            return !Equals(left, right);
        }
    }


}
