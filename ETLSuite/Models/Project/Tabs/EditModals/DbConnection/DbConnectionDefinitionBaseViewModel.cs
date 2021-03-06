﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSuite.Models.Project.Tabs.EditModals.DbConnection
{
    public class DbConnectionDefinitionBaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConnectionStringDisplay { get; set; }
        public string Type { get; set; }
    }
}
