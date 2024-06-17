using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.Data;
using FinanceManagement.DATA.IRepo;

namespace FinanceManagement.DATA.Repo
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(FinanceDbContext context) : base(context) { }
    }
}
