using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETLSuite.Data;
using ETLSuite.Data.Entities;

namespace ETLSuite.Business.Services
{
    public interface IDbConnectionDefinitionService
    {
        IEnumerable<DbConnectionDefinition> GetByProjectId(int projectId);
    }
    public class DbConnectionDefinitionService : ServiceBase, IDbConnectionDefinitionService
    {
        public DbConnectionDefinitionService(IUnitOfWork uow) : base(uow)
        {
        }

        public IEnumerable<DbConnectionDefinition> GetByProjectId(int projectId)
        {
            return uow.DbConnectionDefinitionRepository.Get()
                .Where(x => x.ProjectId == projectId);
        }
    }
}
