using Dolittle.SDK.Concepts;

namespace kitchenator.Domain.Concepts.Ingredients
{

    public class IngredientName : ConceptAs<string>
    {
        /// <summary>
        /// Defines a static, empty state for IngredientName
        /// </summary>
        public static IngredientName Empty { get; } = string.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for IngredientName
        /// </summary>
        public IngredientName() => Value = Empty;

        public IngredientName(string value) => Value = value;

        public IngredientName(IngredientName concept) => Value = concept.Value;

        public static implicit operator IngredientName(string value) => new IngredientName(value);
    }
}
