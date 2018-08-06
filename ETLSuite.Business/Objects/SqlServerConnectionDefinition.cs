using ETLSuite.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ETLSuite.Business.Objects
{
    public class SqlServerConnectionDefinition : DbConnectionDefinitionBase
    {
        public SqlServerConnectionDefinition() { }
        public SqlServerConnectionDefinition(int id, string name, string description, string connectionString) : base(id, name, description, DatabaseType.SqlServer)
        {
            ConnectionString = new SqlConnectionStringBuilder(connectionString);   
        }

        public SqlConnectionStringBuilder ConnectionString { get; private set; }
    }
}
