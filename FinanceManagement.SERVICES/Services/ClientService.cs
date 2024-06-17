using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.IRepo;
using FinanceManagement.SERVICES.Interface;

namespace FinanceManagement.SERVICES.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync() => await _clientRepository.GetAllAsync();
        public async Task<Client> GetClientByIdAsync(Guid id) => await _clientRepository.GetByIdAsync(id);
        public async Task AddClientAsync(Client client) => await _clientRepository.AddAsync(client);
        public async Task UpdateClientAsync(Client client) => await _clientRepository.UpdateAsync(client);
        public async Task DeleteClientAsync(Guid id) => await _clientRepository.DeleteAsync(id);


        /*private readonly IEmployeeRepository _employeeRepository;
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
            await _employeeProjectRepository.FindAsync(ep => ep.EmployeeId == employeeId);*/


    }
}
