using SpaApp.Shared;
using SpaApp.Shared.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaApp.DataAccess.CosmosDb
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<Employee> AddEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployeeAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
