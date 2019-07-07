using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaApp.Shared;
using SpaApp.Shared.DataAccess;

namespace SpaApp.Server.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            Employee addedEmployee = await this.employeeRepository.UpdateEmployeeAsync(employee);
            return CreatedAtRoute("GetEmployee", new { addedEmployee.id }, addedEmployee);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            Employee updatedEmployee = await this.employeeRepository.UpdateEmployeeAsync(employee);
            return AcceptedAtRoute("GetEmployee", new { updatedEmployee.id }, updatedEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            IEnumerable<Employee> employees = await this.employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<IActionResult> GetEmployee(string id)
        {
            Employee employee = await this.employeeRepository.GetEmployeeAsync(id);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            await this.employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}