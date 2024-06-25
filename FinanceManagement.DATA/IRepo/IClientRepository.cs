using FinanceManagement.CORE.Entities;

namespace FinanceManagement.DATA.IRepo
{
    public interface IClientRepository : IRepository<Client>
    {
        // public interface IClientRepository : IRepository<Client> { }
        Task<List<Client>> GetAllClientsAsync();
        Task<Client> AddnewClientAsync(Client cliendt);
    }
}
