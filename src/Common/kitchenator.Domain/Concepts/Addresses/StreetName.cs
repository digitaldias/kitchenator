namespace kitchenator.Domain.Concepts.Addresses
{

    public record StreetName : RecordOf<string>
    {
        /// <summary>
        /// Defines a static, empty state for StreetName
        /// </summary>
        public static StreetName Empty { get; } = string.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for StreetName
        /// </summary>
        public StreetName() => Value = Empty.Value;

        public StreetName(string value) => Value = value;

        public static implicit operator StreetName(string value) => new StreetName(value);
    }
}
