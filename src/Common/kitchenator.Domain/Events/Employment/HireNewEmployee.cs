using Dolittle.SDK.Events;
using kitchenator.Domain.Concepts.Addresses;
using kitchenator.Domain.Concepts.Employees;
using kitchenator.Domain.Concepts.Money;
using kitchenator.Domain.Concepts.People;
using kitchenator.Domain.Concepts.Realestate;
using System;

namespace kitchenator.Domain.Events.Employment
{
    [EventType("8205dcea-2d64-4a76-9ad8-56bbd48eed3c", generation: 0)]
    public class HireNewEmployee : CommandEvent
    {
        public EmployeeId EmployeeId { get; set; }

        public RestaurantId RestaurantId { get; set; }

        public GivenName GivenName { get; set; }

        public FamilyName FamilyName{ get; set; }

        public Address HomeAddress { get; set; }

        public Salary Salary { get; set; }

        public DateTimeOffset StartDate { get; set; }
    }
}
