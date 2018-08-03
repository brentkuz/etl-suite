using ETLSuite.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSuite.Models.Project
{
    public class ProjectInfoViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int SelectedStatus { get; set; }
        public Dictionary<int, string> StatusOptions { get; set; }
    }
}
