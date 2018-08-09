using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ETLSuite.Business.Factories;
using ETLSuite.Business.Objects;
using ETLSuite.Data;
using ETLSuite.Data.Entities;

namespace ETLSuite.Business.Services
{
    public interface IDbConnectionDefinitionService
    {
        IEnumerable<DbConnectionDefinition> GetAllByProjectId(int projectId);
        DbConnectionDefinitionBase GetById(int id);
        bool SaveSqlServerConnection(SqlServerConnectionDefinition connection);
    }
    public class DbConnectionDefinitionService : ServiceBase, IDbConnectionDefinitionService
    {
        private IDbConnectionDefinitionFactory definitionFactory;
        public DbConnectionDefinitionService(IUnitOfWork uow, IDbConnectionDefinitionFactory definitionFactory) : base(uow)
        {
            this.definitionFactory = definitionFactory;
        }

        public IEnumerable<DbConnectionDefinition> GetAllByProjectId(int projectId)
        {
            return uow.DbConnectionDefinitionRepository.Get()
                .Where(x => x.ProjectId == projectId);
        }

        public DbConnectionDefinitionBase GetById(int id)
        {
            var entity = uow.DbConnectionDefinitionRepository.Get()
                .Where(x => x.Id == id).SingleOrDefault();

            return definitionFactory.GetConnectionDefinition(entity);
        }

        public bool SaveSqlServerConnection(SqlServerConnectionDefinition connection)
        {
            var inDb = uow.DbConnectionDefinitionRepository.Get()
                .Where(x => x.Id == connection.Id).SingleOrDefault();

            inDb.Name = connection.Name;
            inDb.ConnectionString = connection.ConnectionString.ConnectionString;

            uow.DbConnectionDefinitionRepository.Update(inDb);

            return uow.Save() > 0;
        }
        
    }
}
