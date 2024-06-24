//using FinanceManagement.CORE.DTO;
using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.IRepo;
using FinanceManagement.SERVICES.Interface;

namespace FinanceManagement.SERVICES.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeProjectRepository _employeeProjectRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeProjectRepository employeeProjectRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeProjectRepository = employeeProjectRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync() => await _employeeRepository.GetAllAsync();

        public async Task<Employee> GetEmployeeByIdAsync(Guid id) => await _employeeRepository.GetByIdAsync(id);

        public async Task AddEmployeeAsync(Employee employee) => await _employeeRepository.AddAsync(employee);

        public async Task UpdateEmployeeAsync(Employee employee) => await _employeeRepository.UpdateAsync(employee);

        public async Task DeleteEmployeeAsync(Guid id) => await _employeeRepository.DeleteAsync(id);

        public async Task<IEnumerable<Employee>> GetTeamMembersAsync(Guid managerId) =>
            await _employeeRepository.FindAsync(e => e.ProjectManagerId == managerId);

        public async Task<IEnumerable<EmployeeProject>> GetEmployeeProjectsAsync(Guid employeeId) =>
            await _employeeProjectRepository.FindAsync(ep => ep.EmployeeId == employeeId);

        /*public async Task<Employee> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                EmployeeId = employeeCreateDto.EmployeeId,
                FirstName = employeeCreateDto.FirstName,
                LastName = employeeCreateDto.LastName,
                Email = employeeCreateDto.Email,
                PasswordHash = employeeCreateDto.PasswordHash,
                MobileNo = employeeCreateDto.MobileNo,
                DateOfJoining = employeeCreateDto.DateOfJoining,
                ProjectManagerId = employeeCreateDto.ProjectManagerId,
                EmployeeStatus = employeeCreateDto.EmployeeStatus,
                SkillSets = employeeCreateDto.SkillSets,
                RoleId = employeeCreateDto.RoleId
            };

            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveAsync();

            return employee;
        }*/

    }
}
