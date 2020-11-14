using Dolittle.SDK.Concepts;
using System;

namespace kitchenator.Domain.Concepts.Ingredients
{
    public class IngredientId : ConceptAs<Guid>
    {
        /// <summary>
        /// Defines a static, empty state for IngredientId
        /// </summary>
        public static IngredientId Empty { get; } = Guid.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for IngredientId
        /// </summary>
        public IngredientId() => Value = Empty;

        public IngredientId(Guid value) => Value = value;

        public IngredientId(IngredientId concept) => Value = concept.Value;

        public static implicit operator IngredientId(Guid value) => new IngredientId(value);
    }
}
