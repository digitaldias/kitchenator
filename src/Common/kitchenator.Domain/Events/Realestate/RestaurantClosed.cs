using Dolittle.SDK.Events;
using System;

namespace kitchenator.Domain.Events.Realestate
{
    [EventType("707bad96-6974-460e-a898-bc6bfac1f12b", generation: 0)]
    public class RestaurantClosed
    {
        public Guid RestaurantId { get; set; }
        public DateTimeOffset ClosedTime { get; set; }
    }
}
