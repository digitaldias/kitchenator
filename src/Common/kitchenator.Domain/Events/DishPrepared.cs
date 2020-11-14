// DishPrepared.cs
using Dolittle.SDK.Events;

namespace kitchenator.Domain.Events
{
    [EventType("8B811E43-81CE-414D-BBA8-DAB661038FDE")]
    public class DishPrepared
    {
        public DishPrepared(string dish, string chef, long timestamp)
        {            
            Dish      = dish;
            Chef      = chef;
            Timestamp = timestamp;
        }
        
        public string Dish { get; internal set; }
        public string Chef { get; internal set; }
        public long   Timestamp { get; internal set; }
    }
}