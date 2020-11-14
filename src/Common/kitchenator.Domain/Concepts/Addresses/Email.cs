namespace kitchenator.Domain.Concepts.Addresses
{

    public record Email : RecordOf<string>
    {
        /// <summary>
        /// Defines a static, empty state for Email
        /// </summary>
        public static Email Empty { get; } = string.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for Email
        /// </summary>
        public Email() => Value = Empty.Value;

        public Email(string value) => Value = value;

        public static implicit operator Email(string value) => new Email(value);
    }
}
