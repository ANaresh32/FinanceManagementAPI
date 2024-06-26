using FinanceManagement.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        Task<Employee> AuthenticateAsync(string email, string password); // New method for authentication
    }
}
