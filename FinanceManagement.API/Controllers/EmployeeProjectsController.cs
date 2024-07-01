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
            if (employeeProjects == null)
            {
                return Ok(new { message = "No project exist." });
            }
            return Ok(employeeProjects);
        }

        /*[HttpGet("{employeeId}")]
        public async Task<ActionResult<EmployeeProject>> GetEmployeeProject(Guid employeeId)
        {
            var employeeProject = await _employeeProjectService.GetEmployeeProjectByIdAsync(employeeId);
            if (employeeProject == null)
            {
                return NotFound();
            }
            return Ok(employeeProject);
        }*/
        [HttpGet("{employeeId}/{projectId}")]
        public async Task<ActionResult<EmployeeProject>> GetEmployeeProject(Guid employeeId, Guid projectId)
        {
            var employeeProject = await _employeeProjectService.GetEmployeeProjectByIdAsync(employeeId, projectId);
            if (employeeProject == null)
            {
                return NotFound(new { message = "No project exist for provided employee." });
            }
            return Ok(employeeProject);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeProject>> AssignEmployeeProject([FromBody] EmployeeProject employeeProject)
        {
            await _employeeProjectService.AddEmployeeProjectAsync(employeeProject);
            return CreatedAtAction(nameof(GetEmployeeProject), new { employeeId = employeeProject.EmployeeId, projectId = employeeProject.ProjectId }, employeeProject);
        }

        [HttpPut("{employeeId}")]///*/{projectId}*/
        public async Task<IActionResult> ReassignEmployeeProject(Guid employeeId, [FromBody] EmployeeProject employeeProject)//, Guid projectId,
        {
            if (employeeId != employeeProject.EmployeeId)// || projectId != employeeProject.ProjectId)
            {
                return BadRequest(new { message = "Details not matching." });
            }
            else if (employeeProject == null)
            {
                return NotFound(new { message = "No projects exist for provided employee." });
            }
            await _employeeProjectService.UpdateEmployeeProjectAsync(employeeProject);
            return Ok(new { message = "Employee project details updated sucessfully." });
        }

        [HttpDelete("{employeeId}/{projectId}")]
        public async Task<IActionResult> DeassignEmployeeProject(Guid employeeId, Guid projectId)
        {
            await _employeeProjectService.DeleteEmployeeProjectAsync(employeeId, projectId);
            return Ok(new { message = "Employee project details deleted succesfully." });
        }
    }
}
