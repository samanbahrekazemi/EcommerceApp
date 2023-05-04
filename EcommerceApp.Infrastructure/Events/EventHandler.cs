using EcommerceApp.Domain.Interfaces;
using System.Collections.Concurrent;

namespace EcommerceApp.Infrastructure.Events
{
    public class EventHandler : IEventHandler
    {

        private readonly ConcurrentDictionary<Type, List<Func<object, Task>>> _subscriptions = new ConcurrentDictionary<Type, List<Func<object, Task>>>();


        public EventHandler() : base()
        {
        }

        public async Task PublishAsync<T>(T @event) where T : IEvent
        {
            if (_subscriptions.TryGetValue(@event.GetType(), out var actions))
            {
                foreach (var action in actions)
                    await action(@event);
            }
        }
    }
}
