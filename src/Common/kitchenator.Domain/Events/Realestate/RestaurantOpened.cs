using Dolittle.SDK.Events;
using System;

namespace kitchenator.Domain.Events.Realestate
{
    [EventType("15f7f08a-1fcd-4035-bc53-64392a262ff8", generation: 0)]
    public class RestaurantOpened
    {
        public Guid RestaurantId { get; set; }

        public DateTimeOffset OpenedTime { get; set; }
    }
}