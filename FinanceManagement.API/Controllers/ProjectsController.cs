using FinanceManagement.API.Extensions;
using FinanceManagement.API.Models.Response;
using FinanceManagement.CORE.Entities;
using FinanceManagement.SERVICES.Interface;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore.Internal;
namespace FinanceManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }
       
        [HttpGet("GetAllProjects")]
        public async Task<ItemResponse> GetAllProjects()
        {
            ItemResponse response = new ItemResponse();
            try
            {
                 response.Item = await _projectService.GetAllProjectsAsync();
                 response.IsSuccess = true;
            }
            catch(FinanceException ex)
            {
                response.Error = ex.ToError();
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
            }
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(Guid id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }
        [HttpPost("NewProject")]
        public async Task<ItemResponse> AddNewProject(Project project)
        {
            ItemResponse response = new ItemResponse();
            try
            {
                response.Item = await _projectService.AddProjectAsync(project);
                response.IsSuccess = true;
            }
            catch(FinanceException ex)
            {
                response.Error = ex.ToError();
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
            }

            return response;
        }
       
        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(Project project)
        {
            await _projectService.AddProjectAsync(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest(new { message = "Project ID Does Not Exist." });
            }

            await _projectService.UpdateProjectAsync(project);
            return Ok(new { message = "Project Updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            await _projectService.DeleteProjectAsync(id);
            return Ok(new { message = "Project Deleted successfully." });
        }
    }
}
