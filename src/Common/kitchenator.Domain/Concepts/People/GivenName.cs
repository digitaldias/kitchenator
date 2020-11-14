using Dolittle.SDK.Concepts;

namespace kitchenator.Domain.Concepts.People
{

    public class GivenName : ConceptAs<string>
    {
        /// <summary>
        /// Defines a static, empty state for GivenName
        /// </summary>
        public static GivenName Empty { get; } = string.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for GivenName
        /// </summary>
        public GivenName() => Value = Empty;

        public GivenName(string value) => Value = value;

        public GivenName(GivenName concept) => Value = concept.Value;

        public static implicit operator GivenName(string value) => new GivenName(value);
    }
}
