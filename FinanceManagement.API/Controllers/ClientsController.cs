using FinanceManagement.CORE.Entities;
using FinanceManagement.SERVICES.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("GetAllClients")]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }
        [HttpPost("Add")]
        public async Task<ActionResult<Client>> AddnewClient(Client client)
        {
            var clients = await _clientService.AddClientAsync(client);
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(Guid id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            await _clientService.AddClientAsync(client);
            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest(new { message = "Client ID Does Not Exist." });
            }

            await _clientService.UpdateClientAsync(client);
            return Ok(new { message = "Client Updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            await _clientService.DeleteClientAsync(id);
            return Ok(new { message = "Client Deleted successfully." });
        }
    }
}
