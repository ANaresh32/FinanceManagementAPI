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

        public async Task<Employee> GetByEmailAsync(string email,string password)
        {
            var result= await _dbSet.FirstOrDefaultAsync(e => e.Email == email && e.PasswordHash==password);
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}
