﻿using FinanceManagement.CORE.Entities;
using FinanceManagement.SERVICES.Interface;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            if (projects == null)
            {
                return NotFound(new { message = "No projects exist." });
            }
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(Guid id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound(new { message = "No projects exist for provided ID." });
            }
            return Ok(project);
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
                return BadRequest(new { message = "Project ID does not exist." });
            }
            await _projectService.UpdateProjectAsync(project);
            return Ok(new { message = "Project updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            await _projectService.DeleteProjectAsync(id);
            return Ok(new { message = "Project deleted successfully." });
        }
    }
}
