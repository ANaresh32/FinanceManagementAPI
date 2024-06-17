using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.IRepo;
using FinanceManagement.SERVICES.Interface;

namespace FinanceManagement.SERVICES.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync() => await _roleRepository.GetAllAsync();
        public async Task<Role> GetRoleByIdAsync(Guid id) => await _roleRepository.GetByIdAsync(id);
        public async Task AddRoleAsync(Role role) => await _roleRepository.AddAsync(role);
        public async Task UpdateRoleAsync(Role role) => await _roleRepository.UpdateAsync(role);
        public async Task DeleteRoleAsync(Guid id) => await _roleRepository.DeleteAsync(id);
    }
}
