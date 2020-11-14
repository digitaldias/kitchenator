namespace kitchenator.Domain.Concepts.Realestate
{

    public record EmployeeCapacity : RecordOf<int>
    {
        /// <summary>
        /// Defines a static, empty state for EmployeeCapacity
        /// </summary>
        public static EmployeeCapacity Empty { get; } = 0;

        /// <summary>
        /// Default constructor uses the static empty state for EmployeeCapacity
        /// </summary>
        public EmployeeCapacity() => Value = Empty.Value;

        public EmployeeCapacity(int value) => Value = value;

        public static implicit operator EmployeeCapacity(int value) => new EmployeeCapacity(value);
    }
}
