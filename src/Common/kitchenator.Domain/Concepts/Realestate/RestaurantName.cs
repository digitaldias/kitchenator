namespace kitchenator.Domain.Concepts.Realestate
{
    public record RestaurantName : RecordOf<string>
    {
        /// <summary>
        /// Defines a static, empty state for RestaurantName
        /// </summary>
        public static RestaurantName Empty { get; } = new RestaurantName(string.Empty);

        /// <summary>
        /// Default constructor uses the static empty state for RestaurantName
        /// </summary>
        public RestaurantName() => Value = Empty.Value;
        public RestaurantName(string value) => Value = value;

        public static implicit operator RestaurantName(string value) => new RestaurantName(value);

        public override string ToString()
        {
            return Value;
        }
    }
}
