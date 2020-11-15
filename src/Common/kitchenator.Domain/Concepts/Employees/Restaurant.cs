using kitchenator.Domain.Concepts.Addresses;
using System;

namespace kitchenator.Domain.Concepts.Employees
{
    public class Restaurant : IReadModel
    {
        public Restaurant()
        {
            Id                = Guid.NewGuid();
            CloseDate         = DateTime.MaxValue;
            CurrentlyEmployed = 0;
        }

        public Restaurant(Realestate.Restaurant restaurant)
        {
            Id                = restaurant.Id;
            Name              = restaurant.Name;
            Address           = restaurant.Address;
            EmployeeCapacity  = restaurant.ChefCapacity;
        }

        public Guid Id{ get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public int EmployeeCapacity { get; set; }

        public int CurrentlyEmployed { get; set; }

        public DateTime CloseDate { get; set; }
    }
}
