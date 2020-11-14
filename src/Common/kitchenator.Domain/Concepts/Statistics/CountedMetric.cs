namespace kitchenator.Domain.Concepts.Statistics
{
    public class CountedMetric
    {
        public CountedMetric(string title, int count)
        {
            Title = title;
            Count = count;
        }
        public string Title { get; set; }

        public int Count { get; set; }
    }
}
