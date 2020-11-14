using Dolittle.SDK.Events;
using kitchenator.Domain.Concepts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kitchenator.Domain.Events
{
    [EventType("77711E43-81CE-414D-BBA8-DAB666038FDE")]
    public class GroceryShoppingRequested
    {
        List<GroceryItem> _shoppingList = Enumerable.Empty<GroceryItem>().ToList();

        public GroceryShoppingRequested(IEnumerable<GroceryItem> shoppingList)
        {
            _shoppingList = new List<GroceryItem>(shoppingList);
        }

        public IEnumerable<GroceryItem> ShoppingList => _shoppingList;
    }
}
