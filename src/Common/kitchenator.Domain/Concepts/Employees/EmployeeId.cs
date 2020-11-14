using Dolittle.SDK.Concepts;
using System;

namespace kitchenator.Domain.Concepts.Employees
{

    public class EmployeeId : ConceptAs<Guid>
    {
        /// <summary>
        /// Defines a static, empty state for EmployeeId
        /// </summary>
        public static EmployeeId Empty { get; } = Guid.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for EmployeeId
        /// </summary>
        public EmployeeId() => Value = Empty;

        public EmployeeId(Guid value) => Value = value;

        public EmployeeId(EmployeeId concept) => Value = concept.Value;

        public static implicit operator EmployeeId(Guid value) => new EmployeeId(value);
    }
}
