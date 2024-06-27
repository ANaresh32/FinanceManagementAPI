using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.IRepo;
using FinanceManagement.SERVICES.Interface;

namespace FinanceManagement.SERVICES.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _clientRepository.GetAllClientsAsync();

        }
        public async Task<Client> AddClientAsync(Client client)
        {
            return await _clientRepository.AddnewClientAsync(client);

        }
       // public async Task<IEnumerable<Client>> GetAllClientsAsync() => await _clientRepository.GetAllAsync();
        public async Task<Client> GetClientByIdAsync(Guid id) => await _clientRepository.GetByIdAsync(id);
        //public async Task AddClientAsync(Client client) => await _clientRepository.AddAsync(client);
        public async Task UpdateClientAsync(Client client) => await _clientRepository.UpdateAsync(client);
        public async Task DeleteClientAsync(Guid id) => await _clientRepository.DeleteAsync(id);
    }
}
