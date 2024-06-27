﻿using FinanceManagement.CORE.Entities;

namespace FinanceManagement.DATA.IRepo
{
    public interface IProjectRepository : IRepository<Project>
    {
        //public interface IProjectRepository : IRepository<Project> { }
       Task<Project> AddNewProjectAsync(Project project);
       Task<List<Project>> GetAllProjectsAsync();
    }
}
