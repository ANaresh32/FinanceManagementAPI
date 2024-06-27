using FinanceManagement.CORE.Entities;

namespace FinanceManagement.SERVICES.Interface
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(Guid id);
        Task <Client> AddClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(Guid id);
       
    }
}
