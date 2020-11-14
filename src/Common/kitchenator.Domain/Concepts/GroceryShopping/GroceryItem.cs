using Dolittle.SDK.Concepts;

namespace kitchenator.Domain.Concepts
{
    public class GroceryItem 
    {
        public string Name { get; set; }

        public double Quantity { get; set; }

        public string Unit { get; set; }

        public GroceryItem(string name, double quantity, string unit)
        {
            Name     = name;
            Quantity = quantity;
            Unit     = unit;
        }
    }
}
