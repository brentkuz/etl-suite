using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSuite.Models.Project
{
    public class ManageViewModel
    {
        public int? ProjectId { get; set; }
        public ManageProjectTab CurrentTab { get; set; }

        public enum ManageProjectTab
        {
            ProjectInfo, ProjectConfiguration, ProjectUploadSchema, ProjectJobs 
        }
    }
}
