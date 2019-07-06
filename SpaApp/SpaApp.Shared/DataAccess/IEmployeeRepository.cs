using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaApp.Shared.DataAccess
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        Task<Employee> GetEmployeeAsync(string id);
        Task<Employee> AddEmployeeAsync(Employee employee);

        Task<Employee> UpdateEmployee(Employee employee);

        Task DeleteEmployeeAsync(string id);
    }
}
