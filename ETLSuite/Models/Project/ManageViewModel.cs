using ETLSuite.Crosscutting.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSuite.Models.Project
{
    public class ManageViewModel : ViewModelBase
    {
        [ClientConfiguration]
        public int? ProjectId { get; set; }
        [ClientConfiguration]
        public ManageProjectTab CurrentTab { get; set; } = ManageProjectTab.ProjectInfo;

        public enum ManageProjectTab
        {
            ProjectInfo, ProjectConfiguration, ProjectUploadSchema, ProjectJobs 
        }
    }
}
