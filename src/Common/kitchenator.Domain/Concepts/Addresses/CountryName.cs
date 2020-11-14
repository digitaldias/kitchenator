namespace kitchenator.Domain.Concepts.Addresses
{

    public record CountryName : RecordOf<string>
    {
        /// <summary>
        /// Defines a static, empty state for CountryName
        /// </summary>
        public static CountryName Empty { get; } = string.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for CountryName
        /// </summary>
        public CountryName() => Value = Empty.Value;

        public CountryName(string value) => Value = value;

        public static implicit operator CountryName(string value) => new CountryName(value);
    }
}
