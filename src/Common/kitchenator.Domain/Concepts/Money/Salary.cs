using Dolittle.SDK.Concepts;

namespace kitchenator.Domain.Concepts.Money
{

    public record Salary : RecordOf<decimal>
    {
        /// <summary>
        /// Defines a static, empty state for Salary
        /// </summary>
        public static Salary Empty { get; } = 0m;

        /// <summary>
        /// Default constructor uses the static empty state for Salary
        /// </summary>
        public Salary() => Value = Empty.Value;

        public Salary(decimal value) => Value = value;
        
        public static implicit operator Salary(decimal value) => new Salary(value);
    }
}
