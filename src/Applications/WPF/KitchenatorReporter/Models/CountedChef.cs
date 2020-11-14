using kitchenator.Domain.Concepts.Statistics;

namespace KitchenatorReporter.Models
{

    public class CountedChef : CountedMetric
    {
        public CountedChef(string title, int count) 
            : base(title, count)
        {
        }

        public string Chef => Title;
    }
}
