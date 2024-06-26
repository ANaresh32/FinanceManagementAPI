using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.Data;
using FinanceManagement.DATA.IRepo;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinanceManagement.DATA.Repo
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(FinanceDbContext context) : base(context) { }

        public async Task<Employee> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}
