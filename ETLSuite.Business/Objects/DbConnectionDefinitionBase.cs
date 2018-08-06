using ETLSuite.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETLSuite.Business.Objects
{
    public abstract class DbConnectionDefinitionBase
    {
        public DbConnectionDefinitionBase() {  }
        public DbConnectionDefinitionBase(int id, string name, string description, DatabaseType type)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Type = type;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DatabaseType Type { get; set; }
    }
}
