using FinanceManagement.CORE.Entities;

namespace FinanceManagement.SERVICES.Interface
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(Guid id);
        Task<Project> AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Guid id);
    }
}
