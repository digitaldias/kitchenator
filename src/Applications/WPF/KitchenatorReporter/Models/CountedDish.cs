using kitchenator.Domain.Concepts.Statistics;

namespace KitchenatorReporter.Models
{

    public class CountedDish : CountedMetric
    {
        public CountedDish(string title, int count)
            : base(title, count)
        {            
        }

        public string Dish => Title;
    }
}
