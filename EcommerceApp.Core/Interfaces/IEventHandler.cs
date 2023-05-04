namespace EcommerceApp.Domain.Interfaces
{
    public interface IEventHandler
    {
        Task PublishAsync<T>(T @event) where T : IEvent;
    }

}
