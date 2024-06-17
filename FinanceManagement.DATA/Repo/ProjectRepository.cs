using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.Data;
using FinanceManagement.DATA.IRepo;

namespace FinanceManagement.DATA.Repo
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(FinanceDbContext context) : base(context) { }
    }
}
