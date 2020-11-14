namespace kitchenator.Domain.Concepts.Addresses
{

    public record StreetNumber : RecordOf<string>
    {
        /// <summary>
        /// Defines a static, empty state for StreetNumber
        /// </summary>
        public static StreetNumber Empty { get; } = string.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for StreetNumber
        /// </summary>
        public StreetNumber() => Value = Empty.Value;

        public StreetNumber(string value) => Value = value;

        public static implicit operator StreetNumber(string value) => new StreetNumber(value);
    }
}
