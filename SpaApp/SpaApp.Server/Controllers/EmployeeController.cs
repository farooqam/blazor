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
            Employee addedEmployee = await this.employeeRepository.AddEmployeeAsync(employee);
            return CreatedAtRoute("GetEmployee", new { id = addedEmployee.Id }, addedEmployee);
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<IActionResult> GetEmployee(string id)
        {
            Employee employee = await this.employeeRepository.GetEmployeeAsync(id);
            return Ok(employee);
        }
    }
}