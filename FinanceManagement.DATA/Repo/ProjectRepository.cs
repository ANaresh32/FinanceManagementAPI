using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.Data;
using FinanceManagement.DATA.IRepo;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagement.DATA.Repo
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly FinanceDbContext _context;
        public ProjectRepository(FinanceDbContext context) : base(context)
        { 
            _context= context;
        
        }
        public async Task<Project> AddNewProjectAsync(Project project)
        {
            var isExsit = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectName == project.ProjectName);
            if (isExsit != null)
            {
                return null;
            }
            Guid projectid = Guid.NewGuid();
            project.Id = projectid;

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }
    }
}
