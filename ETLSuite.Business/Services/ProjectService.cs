using System;
using System.Collections.Generic;
using System.Text;
using ETLSuite.Data;
using ETLSuite.Data.Entities;

namespace ETLSuite.Business.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAll();
        bool CreateEmptyProject(string projectName, out int id);
    }

    public class ProjectService : ServiceBase, IProjectService
    {
        public ProjectService(IUnitOfWork uow) : base(uow)
        {
        }

        public IEnumerable<Project> GetAll()
        {
            return uow.ProjectRepository.Get();
        }

        public bool CreateEmptyProject(string projectName, out int id)
        {
            var project = new Project
            {
                Name = projectName
            };
            uow.ProjectRepository.Insert(project);

            id = project.Id;

            return uow.Save() > 0;
        }

    }
}
