using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSuite.Models.Project
{
    public class ManageProjectViewModel
    {
        public ManageProjectTab CurrentTab { get; set; }

        public enum ManageProjectTab
        {
            Info, Config, Schema, Jobs 
        }
    }
}
