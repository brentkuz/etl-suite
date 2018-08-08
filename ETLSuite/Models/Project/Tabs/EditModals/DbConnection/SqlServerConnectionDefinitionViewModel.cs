using ETLSuite.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ETLSuite.Models.Project.Tabs.EditModals.DbConnection
{
    public class SqlServerConnectionDefinitionViewModel : DbConnectionDefinitionBaseViewModel
    {
        //Connection String parts
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public int ConnectionRetryCount { get; set; }
        public int ConnectionRetryInterval { get; set; }
        public int ConnectionTimeout { get; set; }
        public bool Encrypt { get; set; }
        public bool IntegratedSecurity { get; set; }
        public bool MultipleActiveResultSets { get; set; }
        public string Password { get; set; }
        public string UserID { get; set; }

    }
}
