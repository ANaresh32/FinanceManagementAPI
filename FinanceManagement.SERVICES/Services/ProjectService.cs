using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.IRepo;
using FinanceManagement.SERVICES.Interface;

namespace FinanceManagement.SERVICES.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync() => await _projectRepository.GetAllAsync();
        public async Task<Project> GetProjectByIdAsync(Guid id) => await _projectRepository.GetByIdAsync(id);
        public async Task AddProjectAsync(Project project) => await _projectRepository.AddAsync(project);
        public async Task UpdateProjectAsync(Project project) => await _projectRepository.UpdateAsync(project);
        public async Task DeleteProjectAsync(Guid id) => await _projectRepository.DeleteAsync(id);
    }
}
