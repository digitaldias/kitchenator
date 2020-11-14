namespace kitchenator.Domain.Concepts
{
    public abstract record RecordOf<T>
    {
        public T Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
