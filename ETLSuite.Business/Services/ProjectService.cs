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
    }
}
