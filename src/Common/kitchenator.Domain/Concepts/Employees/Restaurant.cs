using kitchenator.Domain.Concepts.Addresses;
using System;

namespace kitchenator.Domain.Concepts.Employees
{
    public class Restaurant : IReadModel
    {
        public Guid Id{ get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public int EmployeeCapacity { get; set; }

        public int CurrentlyEmployed { get; set; }

        public DateTime CloseDate { get; set; }
    }
}
