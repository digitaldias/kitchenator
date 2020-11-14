using Dolittle.SDK.Concepts;

namespace kitchenator.Domain.Concepts.Money
{

    public record Rent : RecordOf<decimal>
    {
        /// <summary>
        /// Defines a static, empty state for Rent
        /// </summary>
        public static Rent Empty { get; } = 0m;

        /// <summary>
        /// Default constructor uses the static empty state for Rent
        /// </summary>
        public Rent() => Value = Empty.Value;
        public Rent(decimal value) => Value = value;

        public static implicit operator Rent(decimal value) => new Rent(value);
    }
}
