using FinanceManagement.CORE.Entities;

namespace FinanceManagement.SERVICES.Interface
{
    public interface IEmployeeProjectService
    {

        Task<IEnumerable<EmployeeProject>> GetAllEmployeeProjectsAsync();
        //Task<EmployeeProject> GetEmployeeProjectByIdAsync(Guid employeeId);
        Task<EmployeeProject> GetEmployeeProjectByIdAsync(Guid employeeId, Guid projectId);
        Task AddEmployeeProjectAsync(EmployeeProject employeeProject);
        Task UpdateEmployeeProjectAsync(EmployeeProject employeeProject);
        Task DeleteEmployeeProjectAsync(Guid employeeId, Guid projectId);
    }
}
