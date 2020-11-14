namespace kitchenator.Domain.Concepts.Addresses
{

    public record CityName : RecordOf<string>
    {
        /// <summary>
        /// Defines a static, empty state for CityName
        /// </summary>
        public static CityName Empty { get; } = string.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for CityName
        /// </summary>
        public CityName() => Value = Empty.Value;

        public CityName(string value) => Value = value;

        public static implicit operator CityName(string value) => new CityName(value);
    }

}
