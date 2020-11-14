namespace kitchenator.Domain.Concepts.Addresses
{

    public record PostalCode : RecordOf<string>
    {
        /// <summary>
        /// Defines a static, empty state for PostalCode
        /// </summary>
        public static PostalCode Empty { get; } = string.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for PostalCode
        /// </summary>
        public PostalCode() => Value = Empty.Value;

        public PostalCode(string value) => Value = value;

        public static implicit operator PostalCode(string value) => new PostalCode(value);
    }
}
