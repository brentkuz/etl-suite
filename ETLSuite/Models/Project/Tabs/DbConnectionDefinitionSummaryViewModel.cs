using ETLSuite.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSuite.Models.Project.Tabs.DbConnection
{
    public class DbConnectionDefinitionSummaryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DatabaseType Type { get; set; }
        public string TypeDisplay { get; set; }
    }
}
