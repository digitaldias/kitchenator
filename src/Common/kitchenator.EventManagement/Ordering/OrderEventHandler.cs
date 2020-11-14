using Dolittle.SDK.Events;
using Dolittle.SDK.Events.Handling;
using Dolittle.SDK.Events.Store;
using kitchenator.Domain.Events.Orders;
using System;
using System.Threading.Tasks;

namespace kitchenator.EventManagement.Ordering
{
    [EventHandler("2221ae1a-e80c-4ced-9519-fffeb0ce3091", partitioned: true, inScope: null)]
    public class OrderEventHandler
    {
        IEventStore _eventStore;


        public OrderEventHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }


        public Task Handle(OrderPlaced evt, EventContext eventContext)
        {
            return Task.CompletedTask;
        }
    }
}
