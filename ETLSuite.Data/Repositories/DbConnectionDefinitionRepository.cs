using ETLSuite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETLSuite.Data.Repositories
{
    public interface IDbConnectionDefinitionRepository
    {
        IQueryable<DbConnectionDefinition> Get();
        void Insert(DbConnectionDefinition project);
        void Delete(int id);
        void Update(DbConnectionDefinition newValues);
    }
    public class DbConnectionDefinitionRepository : RepositoryBase<DbConnectionDefinition>, IDbConnectionDefinitionRepository
    {
        public DbConnectionDefinitionRepository(ETLDataContext context) : base(context)
        {
        }
    }
}
