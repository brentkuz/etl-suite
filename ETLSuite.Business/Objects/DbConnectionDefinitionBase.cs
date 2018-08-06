using System;
using System.Collections.Generic;
using System.Text;

namespace ETLSuite.Business.Objects
{
    public abstract class DbConnectionDefinitionBase
    {
        public DbConnectionDefinitionBase() {  }
        public DbConnectionDefinitionBase(int id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
