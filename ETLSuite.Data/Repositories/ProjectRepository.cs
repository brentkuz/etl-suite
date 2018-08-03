using ETLSuite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETLSuite.Data.Repositories
{
    public interface IProjectRepository
    {
        IQueryable<Project> Get();
        void Insert(Project project);
        void Delete(int id);
        void Update(Project newValues);
    }

    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(ETLDataContext context) : base(context)
        {
        }

    }
}
