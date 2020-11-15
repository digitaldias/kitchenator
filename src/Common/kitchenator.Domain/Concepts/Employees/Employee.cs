using Dolittle.SDK.Concepts;
using kitchenator.Domain.Concepts.Addresses;
using System;

namespace kitchenator.Domain.Concepts.Employees
{
    public class Employee : Value<Employee>, IReadModel
    {
        public static readonly Employee Empty = new Employee
        {
            Id              = Guid.Empty,
            GivenName       = string.Empty,
            FamilyName      = string.Empty,
            Address         = Address.Empty,
            Email           = string.Empty,
            Salary          = 0m,
            TerminationDate = DateTime.MinValue,
            HireDate        = DateTime.MinValue
        };

        public Guid Id { get; set; }

        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public DateTime TerminationDate { get; set; }
        public DateTime HireDate { get; set; }
    }
}