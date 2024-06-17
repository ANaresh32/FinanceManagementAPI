using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.Data;
using FinanceManagement.DATA.IRepo;

namespace FinanceManagement.DATA.Repo
{
    public class EmployeeProjectRepository : Repository<EmployeeProject>, IEmployeeProjectRepository
    {
        public EmployeeProjectRepository(FinanceDbContext context) : base(context) { }
    }
}
