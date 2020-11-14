using Dolittle.SDK.Concepts;
using System;

namespace kitchenator.Domain.Concepts.Dates
{

    public class TerminationDate : ConceptAs<DateTime>
    {
        /// <summary>
        /// Defines a static, empty state for TerminationDate
        /// </summary>
        public static TerminationDate Empty { get; } = DateTime.MinValue;

        /// <summary>
        /// Default constructor uses the static empty state for TerminationDate
        /// </summary>
        public TerminationDate() => Value = Empty;

        public TerminationDate(DateTime value) => Value = value;

        public TerminationDate(TerminationDate concept) => Value = concept.Value;

        public static implicit operator TerminationDate(DateTime value) => new TerminationDate(value);
    }

}
