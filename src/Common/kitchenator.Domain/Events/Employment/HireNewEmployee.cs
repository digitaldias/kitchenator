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
        public Guid EmployeeId { get; set; }

        public Guid RestaurantId { get; set; }

        public string GivenName { get; set; }

        public string FamilyName{ get; set; }

        public Address HomeAddress { get; set; }

        public decimal Salary { get; set; }

        public DateTimeOffset StartDate { get; set; }
    }
}
