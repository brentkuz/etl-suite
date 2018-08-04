using ETLSuite.Crosscutting.CustomAttributes;
using ETLSuite.Models.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSuite
{
    public class UrlConstants
    {
        //Project 
        public string Project_Create { get; } = "/Project/Create?name=";
        public string Project_GetTab { get; } = "/Project/GetTab?tab=";

        //ProjectData
        public string ProjectData_GetProjects { get; } = "/ProjectData/GetProjects";
        public string ProjectData_GetProjectInfo { get; } = "/ProjectData/GetProjectInfo/";
        public string ProjectData_SaveProjectInfo { get; } = "/ProjectData/SaveProjectInfo";

        //DbConnectionData
        public string DbConnectionData_GetAll { get; } = "/DbConnectionData/GetAll?projectId=";
        public string DbConnectionData_GetDefinition { get; } = "/DbConnectionData/GetDefinition/";
    }
}
