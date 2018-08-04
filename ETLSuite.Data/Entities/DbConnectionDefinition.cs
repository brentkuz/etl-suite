using ETLSuite.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ETLSuite.Data.Entities
{
    [Table("DbConnectionDefinitions")]
    public class DbConnectionDefinition : EntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string ConnectionString { get; set; }
        [Required]
        public DatabaseType Type { get; set; }

        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]        
        public virtual Project Project { get; set; }

    }
}
