using ETLSuite.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Text;

namespace ETLSuite.Business.Objects
{
    public class OracleConnectionDefinition : DbConnectionDefinitionBase
    {
        public OracleConnectionDefinition() { }
        public OracleConnectionDefinition(int id, string name, string description, string connectionString) : base(id, name, description, DatabaseType.Oracle)
        {
            this.ConnectionString = new OracleConnectionStringBuilder(connectionString);
        }

        public OracleConnectionStringBuilder ConnectionString { get; private set; }
    }
}
