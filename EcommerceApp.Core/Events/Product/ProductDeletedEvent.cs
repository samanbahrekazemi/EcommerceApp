using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Shared.DTOs;
using MediatR;

namespace EcommerceApp.Domain.Events.Product
{
    public class ProductDeletedEvent : IEvent, INotification
    {
        public ProductDto? ProductDto { get; set; }

        public Guid Id => Guid.NewGuid();

        public DateTime OccurredOn => DateTime.UtcNow;

        public string? Name { get; set; } = "ProductDeleted";
        public string? Description { get; set; }
    }
}
