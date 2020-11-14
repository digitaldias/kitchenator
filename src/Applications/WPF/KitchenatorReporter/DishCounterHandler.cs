using Dolittle.SDK.Events;
using Dolittle.SDK.Events.Handling;
using kitchenator.Domain.Events;
using KitchenatorReporter.Models;
using PubSub;
using System;
using System.Collections.Generic;

namespace KitchenatorReporter
{
    [EventHandler("AAAECE1E-33E7-4AD3-98E6-CDA6EE289961")]
    public class DishCounterHandler
    {        
        private readonly Hub _hub;

        static Dictionary<string, int> _work  = new Dictionary<string, int>();
        static Dictionary<string, int> _meals = new Dictionary<string, int>();
        

        public DishCounterHandler(Hub hub)
        {
            _hub = hub;
        }

        public void Handle(DishPrepared dishPreparedEvent, EventContext eventContext)
        {            
            if (!_work.ContainsKey(dishPreparedEvent.Chef))
            {
                _work.Add(dishPreparedEvent.Chef, 1);
            }
            else
            {
                _work[dishPreparedEvent.Chef] += 1;
            }

            if(!_meals.ContainsKey(dishPreparedEvent.Dish))
            {
                _meals.Add(dishPreparedEvent.Dish, 1);
            }
            else
            {
                _meals[dishPreparedEvent.Dish] += 1;
            }

            _hub.Publish(new CountedChef(dishPreparedEvent.Chef, _work[dishPreparedEvent.Chef]));
            _hub.Publish(new CountedDish(dishPreparedEvent.Dish, _meals[dishPreparedEvent.Dish]));
        }
    }
}
