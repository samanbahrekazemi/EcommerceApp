namespace EcommerceApp.Domain.Interfaces
{
    public interface IEvent
    {
        Guid Id { get; }
        DateTime OccurredOn { get; }
        string? Name { get; set; }
        string? Description { get; set; }
    }

}
