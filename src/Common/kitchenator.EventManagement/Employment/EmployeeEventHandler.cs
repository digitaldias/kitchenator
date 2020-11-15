using Dolittle.SDK.Events;
using Dolittle.SDK.Events.Handling;
using Dolittle.SDK.Events.Store;
using kitchenator.Domain;
using kitchenator.Domain.Concepts.Employees;
using kitchenator.Domain.Contracts;
using kitchenator.Domain.Events;
using kitchenator.Domain.Events.Employment;
using System;
using System.Threading.Tasks;

namespace kitchenator.EventManagement.Employment
{
    [EventHandler("fb49ad98-281a-4c03-8aaf-49215118a1d7", partitioned: true, inScope: null)]
    public class EmployeeEventHandler : ICanHandleEvents
    {
        readonly IEventStore _eventStore;
        readonly IRepositoryFor<Employee>   _employees;
        readonly IRepositoryFor<Restaurant> _restaurants;

        public EmployeeEventHandler(IEventStore eventStore,
            IRepositoryFor<Employee> employees,
            IRepositoryFor<Restaurant> restaurants)
        {
            _eventStore  = eventStore;
            _employees   = employees;
            _restaurants = restaurants;
        }

        public async Task Handle(HireNewEmployee evt, EventContext eventContext)
        {
            var command = evt as CommandEvent;
            if (command is { })
            {
                await _eventStore.CommitEvent(evt, eventContext.EventSourceId);
            }
        }
    }
}
