using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ETLSuite.Business.Objects
{
    public class SqlServerConnectionDefinition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SqlConnectionStringBuilder ConnectionString { get; set; }
    }
}
