using System;

namespace kitchenator.Domain.Concepts.Realestate
{

    public record RestaurantId : RecordOf<Guid>
    {
        /// <summary>
        /// Defines a static, empty state for RestaurantId
        /// </summary>
        public static RestaurantId Empty { get; } = Guid.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for RestaurantId
        /// </summary>
        public RestaurantId() => Value = Empty.Value;
        public RestaurantId(Guid value) => Value = value;        

        public static implicit operator RestaurantId(Guid value) => new RestaurantId(value);
    }
}
