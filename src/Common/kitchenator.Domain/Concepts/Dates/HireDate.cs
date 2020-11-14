using Dolittle.SDK.Concepts;
using System;

namespace kitchenator.Domain.Concepts.Dates
{

    public class HireDate : ConceptAs<DateTime>
    {
        /// <summary>
        /// Defines a static, empty state for HireDate
        /// </summary>
        public static HireDate Empty { get; } = DateTime.MinValue;

        /// <summary>
        /// Default constructor uses the static empty state for HireDate
        /// </summary>
        public HireDate() => Value = Empty;

        public HireDate(DateTime value) => Value = value;

        public HireDate(HireDate concept) => Value = concept.Value;

        public static implicit operator HireDate(DateTime value) => new HireDate(value);
    }
}
