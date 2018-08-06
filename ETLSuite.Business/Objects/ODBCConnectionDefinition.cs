using ETLSuite.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Text;

namespace ETLSuite.Business.Objects
{
    public class ODBCConnectionDefinition : DbConnectionDefinitionBase
    {
        public ODBCConnectionDefinition() { }
        public ODBCConnectionDefinition(int id, string name, string description, string connectionString) : base(id, name, description, DatabaseType.ODBC)
        {
            this.ConnectionString = new OdbcConnectionStringBuilder(connectionString);
        }

        public OdbcConnectionStringBuilder ConnectionString { get; private set; }
    }
}
