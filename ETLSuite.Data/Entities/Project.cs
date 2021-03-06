﻿using ETLSuite.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ETLSuite.Data.Entities
{
    [Table("Projects")]
    public class Project : EntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public ProjectStatus Status { get; set; }

        public ICollection<DbConnectionDefinition> DbConnectionDefinitions { get; set; }
    }
}
