using kitchenator.Domain.Concepts.Employees;
using kitchenator.Domain.Concepts.People;
using kitchenator.Domain.Contracts.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kitchenator.data.azure
{
    public class EmployeeReader : AzureConnectedTable, IEmployeeReader
    {
        const string CHEFS_TABLE_NAME = "chefs";

        public EmployeeReader()
            : base(CHEFS_TABLE_NAME)
        {
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var entities = await GetAllRecords();

            var chefs = new List<Employee>();
            if(entities.Any())
            {
                chefs.AddRange(entities.Select(e => new Employee
                {
                    EmployeeId      = new EmployeeId(Guid.Parse(e.RowKey)),
                    FamilyName      = new FamilyName(e.PartitionKey),
                    GivenName       = new GivenName(e["name"].StringValue),
                    HireDate        = e["hired"].DateTime ?? DateTime.MinValue,
                    TerminationDate = e["fired"].DateTime ?? DateTime.MaxValue
                }));
            }
            return chefs;
        }
    }
}