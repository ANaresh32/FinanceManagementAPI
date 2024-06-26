using FinanceManagement.CORE.Entities;

namespace FinanceManagement.DATA.IRepo
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetByEmailAsync(string email);

    }
}
