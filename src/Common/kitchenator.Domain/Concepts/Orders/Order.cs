using Dolittle.SDK.Concepts;
using System;
using System.Collections.Generic;
using System.Text;

namespace kitchenator.Domain.Concepts.Orders
{
    public class Order : Value<Order>
    {
        OrderId OrderId { get; set; }
    }
}
