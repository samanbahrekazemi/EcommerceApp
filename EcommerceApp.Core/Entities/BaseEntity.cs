using EcommerceApp.Domain.Interfaces;

namespace EcommerceApp.Domain.Entities
{
    public abstract class BaseEntity<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}
