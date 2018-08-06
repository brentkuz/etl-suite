using ETLSuite.Business.Objects;
using ETLSuite.Crosscutting.Enums;
using ETLSuite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETLSuite.Business.Factories
{
    public interface IDbConnectionDefinitionFactory
    {
        DbConnectionDefinitionBase GetConnectionDefinition(DbConnectionDefinition entity);
    }
    public class DbConnectionDefinitionFactory : IDbConnectionDefinitionFactory
    {
        public DbConnectionDefinitionBase GetConnectionDefinition(DbConnectionDefinition entity)
        {
            switch(entity.Type)
            {
                case DatabaseType.SqlServer:
                    return new SqlServerConnectionDefinition(entity.Id, entity.Name, entity.Description, entity.ConnectionString);
                case DatabaseType.ODBC:
                    return new ODBCConnectionDefinition(entity.Id, entity.Name, entity.Description, entity.ConnectionString);
                case DatabaseType.Oracle:
                    return new OracleConnectionDefinition(entity.Id, entity.Name, entity.Description, entity.ConnectionString);
                default:
                    throw new InvalidOperationException();
            }
        }
    }

}
