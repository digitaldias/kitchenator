using Dolittle.SDK.Concepts;
using kitchenator.Domain.Concepts.Addresses;
using kitchenator.Domain.Concepts.Dates;
using kitchenator.Domain.Concepts.Money;
using kitchenator.Domain.Concepts.People;

namespace kitchenator.Domain.Concepts.Employees
{
    public class Employee : Value<Employee>, IReadModel
    {
        public static readonly Employee Empty = new Employee
        {
            EmployeeId      = EmployeeId.Empty,
            GivenName       = GivenName.Empty,
            FamilyName      = FamilyName.Empty,
            Address         = Address.Empty,
            Email           = Email.Empty,
            Salary          = Salary.Empty,
            TerminationDate = TerminationDate.Empty,
            HireDate        = HireDate.Empty
        };

        public EmployeeId EmployeeId { get; set; }
        public GivenName GivenName { get; set; }
        public FamilyName FamilyName { get; set; }
        public Address Address { get; set; }
        public Email Email { get; set; }
        public Salary Salary { get; set; }
        public TerminationDate TerminationDate { get; set; }
        public HireDate HireDate { get; set; }
    }
}