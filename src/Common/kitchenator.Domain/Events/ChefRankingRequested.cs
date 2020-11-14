using Dolittle.SDK.Events;
using System;

namespace kitchenator.Domain.Events
{    
    [EventType("679012FE-E7C4-48D0-8E23-125EFF036FDC")]
    public class ChefRankingRequested
    {
        Guid Id { get; set; } = Guid.NewGuid();
    }
}
