namespace kitchenator.Domain.Concepts.Addresses
{

    public record CountryCode : RecordOf<string>
    {
        /// <summary>
        /// Defines a static, empty state for CountryCode
        /// </summary>
        public static CountryCode Empty { get; } = string.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for CountryCode
        /// </summary>
        public CountryCode() => Value = Empty.Value;

        public CountryCode(string value) => Value = value;

        public static implicit operator CountryCode(string value) => new CountryCode(value);
    }
}
