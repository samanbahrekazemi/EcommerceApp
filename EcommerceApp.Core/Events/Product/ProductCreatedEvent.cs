using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Shared.DTOs;
using MediatR;

namespace EcommerceApp.Domain.Events.Product
{
    public class ProductCreatedEvent : IEvent , INotification
    {
        public ProductDto ProductDto { get; set; }

        public Guid Id => Guid.NewGuid();

        public DateTime OccurredOn => DateTime.UtcNow;

        public string? Name { get; set; } = "ProductCreated";
        public string? Description { get; set; }
    }

}
