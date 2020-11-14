using Dolittle.SDK.Concepts;
using System;
using System.Collections.Generic;
using System.Text;

namespace kitchenator.Domain.Concepts.Orders
{

    public class OrderId : ConceptAs<Guid>
    {
        /// <summary>
        /// Defines a static, empty state for OrderId
        /// </summary>
        public static OrderId Empty { get; } = Guid.Empty;

        /// <summary>
        /// Default constructor uses the static empty state for OrderId
        /// </summary>
        public OrderId() => Value = Empty;

        public OrderId(Guid value) => Value = value;

        public OrderId(OrderId concept) => Value = concept.Value;

        public static implicit operator OrderId(Guid value) => new OrderId(value);
    }
}
