using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETLSuite.Data;
using ETLSuite.Data.Entities;

namespace ETLSuite.Business.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAll();
        Project GetById(int id);
        bool CreateEmptyProject(string projectName, out int id);
        bool UpdateProjectInfo(Project project);
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

            var success = uow.Save() > 0;
            id = project.Id;

            return success;
        }

        public Project GetById(int id)
        {
            return uow.ProjectRepository.Get()
                .Where(x => x.Id == id).SingleOrDefault();            
        }

        public bool UpdateProjectInfo(Project project)
        {
            var inDb = GetById(project.Id);
            if (inDb == null)
                return false;

            inDb.Name = project.Name;
            inDb.Description = project.Description;
            inDb.Status = project.Status;

            uow.ProjectRepository.Update(inDb);

            return uow.Save() > 0;
        }
    }
}
