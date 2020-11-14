namespace kitchenator.Domain.Concepts
{
    public abstract record ImmutableRecordOf<T>
    {
        public T Value { get; init; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
