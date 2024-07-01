//using FinanceManagement.CORE.DTO;
using FinanceManagement.CORE.Entities;
using FinanceManagement.SERVICES.Interface;
using FinanceManagement.SERVICES.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        /*public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees() =>
        Ok(await _employeeService.GetAllEmployeesAsync());*/

        /*public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            if (clients == null)
            {
                return NotFound(new { message = "No clients exist." });
            }
            return Ok(clients);
        }*/
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var Employees = await _employeeService.GetAllEmployeesAsync();
            if(Employees == null)
            {
                return NotFound(new { message = "No employees exist." });
            }
            return Ok(Employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound(new { message = "No such employees exist." });
            }
            return Ok(employee);
        }

        [HttpGet("{id}/team")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetTeamMembers(Guid id)
        {
            var Employees = await _employeeService.GetEmployeeByIdAsync(id);
            if (Employees == null)
            {
                return NotFound(new { message = "No team member assigned" });
            }
            return Ok(Employees);
        }

        [HttpGet("{employeeId}/projects")]
        public async Task<ActionResult<IEnumerable<EmployeeProject>>> GetEmployeeProjects(Guid employeeId)
        {
            var projects = await _employeeService.GetEmployeeProjectsAsync(employeeId);
            if (projects == null)
            {
                return NotFound(new {message = "No projects assigned"});
            }
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Employee employee)
        {
            await _employeeService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest(new { message = "Employee ID does not exist." });
            }
            await _employeeService.UpdateEmployeeAsync(employee);
            return Ok(new { message = "Employee updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok(new { message = "Employee deleted successfully." });
        }        
    }
}
