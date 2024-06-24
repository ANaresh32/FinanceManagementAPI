using FinanceManagement.CORE.Entities;
using FinanceManagement.SERVICES.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoleById(Guid id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole(Role role)
        {
            if (role.Id == Guid.Empty)
            {
                role.Id = Guid.NewGuid(); // Ensure a new GUID is generated if not provided
            }
            await _roleService.AddRoleAsync(role);
            return CreatedAtAction(nameof(GetRoleById), new { id = role.Id }, role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(Guid id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest(new { message = "Role ID Does Not Exist." });
            }

            await _roleService.UpdateRoleAsync(role);
            return Ok(new { message = "Role updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            await _roleService.DeleteRoleAsync(id);
            return Ok(new { message = "Role Deleted successfully." });
        }
    }
}
