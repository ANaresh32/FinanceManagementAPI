//using FinanceManagement.CORE.DTO;
using FinanceManagement.CORE.Entities;

namespace FinanceManagement.SERVICES.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Guid id);
        Task<IEnumerable<Employee>> GetTeamMembersAsync(Guid managerId);
        Task<IEnumerable<EmployeeProject>> GetEmployeeProjectsAsync(Guid employeeId);

        //Task<Employee> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto);
    }
}
