using FinanceManagement.CORE.Entities;
using FinanceManagement.SERVICES.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeProjectsController : ControllerBase
    {
        private readonly IEmployeeProjectService _employeeProjectService;

        public EmployeeProjectsController(IEmployeeProjectService employeeProjectService)
        {
            _employeeProjectService = employeeProjectService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeProject>>> GetAllEmployeeProjects()
        {
            var employeeProjects = await _employeeProjectService.GetAllEmployeeProjectsAsync();
            return Ok(employeeProjects);
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<EmployeeProject>> GetEmployeeProject(Guid employeeId)
        {
            var employeeProject = await _employeeProjectService.GetEmployeeProjectByIdAsync(employeeId);
            if (employeeProject == null)
            {
                return NotFound();
            }
            return Ok(employeeProject);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeProject>> CreateEmployeeProject([FromBody] EmployeeProject employeeProject)
        {
            await _employeeProjectService.AddEmployeeProjectAsync(employeeProject);
            return CreatedAtAction(nameof(GetEmployeeProject), new { employeeId = employeeProject.EmployeeId, projectId = employeeProject.ProjectId }, employeeProject);
        }

        [HttpPut("{employeeId}")]///*/{projectId}*/
        public async Task<IActionResult> UpdateEmployeeProject(Guid employeeId, [FromBody] EmployeeProject employeeProject)//, Guid projectId,
        {
            if (employeeId != employeeProject.EmployeeId)// || projectId != employeeProject.ProjectId)
            {
                return BadRequest();
            }
            await _employeeProjectService.UpdateEmployeeProjectAsync(employeeProject);
            return NoContent();
        }

        [HttpDelete("{employeeId}")]///*/{projectId}*/
        public async Task<IActionResult> DeleteEmployeeProject(Guid employeeId)
        {
            await _employeeProjectService.DeleteEmployeeProjectAsync(employeeId);
            return NoContent();
        }
    }
}
