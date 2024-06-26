using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.IRepo;
using FinanceManagement.SERVICES.Interface;

namespace FinanceManagement.SERVICES.Services
{
    public class EmployeeProjectService : IEmployeeProjectService
    {
        private readonly IEmployeeProjectRepository _employeeProjectRepository;

        public EmployeeProjectService(IEmployeeProjectRepository employeeProjectRepository)
        {
            _employeeProjectRepository = employeeProjectRepository;
        }
        public async Task<IEnumerable<EmployeeProject>> GetAllEmployeeProjectsAsync() => await _employeeProjectRepository.GetAllAsync();
        //public async Task<EmployeeProject> GetEmployeeProjectByIdAsync(Guid employeeId) => await _employeeProjectRepository.GetByIdAsync(employeeId);
        public async Task<EmployeeProject> GetEmployeeProjectByIdAsync(Guid employeeId, Guid projectId) => await _employeeProjectRepository.GetByIdAsync(employeeId, projectId);
        public async Task AddEmployeeProjectAsync(EmployeeProject employeeProject) => await _employeeProjectRepository.AddAsync(employeeProject);
        public async Task UpdateEmployeeProjectAsync(EmployeeProject employeeProject) => await _employeeProjectRepository.UpdateAsync(employeeProject);
        public async Task DeleteEmployeeProjectAsync(Guid employeeId) => await _employeeProjectRepository.DeleteAsync(employeeId);
    }
}
