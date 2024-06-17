using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.Data;
using FinanceManagement.DATA.IRepo;

namespace FinanceManagement.DATA.Repo
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(FinanceDbContext context) : base(context) { }
    }
}
