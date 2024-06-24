//using FinanceManagement.CORE.DTO;
using FinanceManagement.CORE.Entities;
using FinanceManagement.SERVICES.Interface;
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
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees() =>
        Ok(await _employeeService.GetAllEmployeesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpGet("{id}/team")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetTeamMembers(Guid id) =>
            Ok(await _employeeService.GetTeamMembersAsync(id));

        [HttpGet("{employeeId}/projects")]
        public async Task<ActionResult<IEnumerable<EmployeeProject>>> GetEmployeeProjects(Guid employeeId)
        {
            var projects = await _employeeService.GetEmployeeProjectsAsync(employeeId);
            if (projects == null)
            {
                return NotFound();
            }
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult> PostEmployee(Employee employee)
        {
            await _employeeService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest(new { message = "Employee ID Does Not Exist." });
            }
            await _employeeService.UpdateEmployeeAsync(employee);
            return Ok(new { message = "Employee Updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok(new { message = "Employee Deleted successfully." });
        }        
    }
}
