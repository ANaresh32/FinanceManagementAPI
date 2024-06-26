using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.Data;
using FinanceManagement.DATA.IRepo;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagement.DATA.Repo
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly FinanceDbContext _context;
        public ClientRepository(FinanceDbContext context) : base(context)
        {
            _context= context;
        }
        public async Task<List<Client>> GetAllClientsAsync()
        {
            var result = await _context.Clients.ToListAsync();
            if (result == null)
            {
                return null;
            }
            return result;
        }
        public async Task<Client> AddnewClientAsync(Client client)
        {
            var IsExist=await _context.Clients.FirstOrDefaultAsync(x=>x.ClientEmailId==client.ClientEmailId);
            if (IsExist != null) {
                return null;
            }
            Guid id = Guid.NewGuid();
            client.Id = id;
           
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }
    }
}
