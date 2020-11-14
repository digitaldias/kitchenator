using Dolittle.SDK.Concepts;

namespace kitchenator.Domain.Concepts.People
{

    public class FamilyName : ConceptAs<string>
    {
        /// <summary>
        /// Defines a static, empty state for FamilyName
        /// </summary>
        public static FamilyName Empty { get; } = string.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for FamilyName
        /// </summary>
        public FamilyName() => Value = Empty;

        public FamilyName(string value) => Value = value;

        public FamilyName(FamilyName concept) => Value = concept.Value;

        public static implicit operator FamilyName(string value) => new FamilyName(value);
    }
}
