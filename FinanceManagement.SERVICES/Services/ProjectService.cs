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
        public async Task<Project> AddProjectAsync(Project project)
        {
            var result = await _projectRepository.AddNewProjectAsync(project);
            if (result == null)
            {
                throw new FinanceException("AL001", "Project Name already exsit");
            }
            return result;
        }
        public async Task<List<Project>> GetAllProjectsAsync()
        {
           
            return await _projectRepository.GetAllProjectsAsync(); ;
        }
       // public async Task<List<Project>> GetAllProjectsAsync() => await _projectRepository.GetAllAsync();
        public async Task<Project> GetProjectByIdAsync(Guid id) => await _projectRepository.GetByIdAsync(id);
       // public async Task<Project> AddProjectAsync(Project project) => await _projectRepository.AddAsync(project);
        public async Task UpdateProjectAsync(Project project) => await _projectRepository.UpdateAsync(project);
        public async Task DeleteProjectAsync(Guid id) => await _projectRepository.DeleteAsync(id);
    }
}
