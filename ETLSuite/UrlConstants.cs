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
        public string Project_GetTab { get; } = "/Project/GetTabTemplate?tab=";
        public string Project_GetDbConnectionEditTemplate { get; } = "/Project/GetDbConnectionEditTemplate?type=";

        //ProjectData
        public string ProjectData_GetProjects { get; } = "/ProjectData/GetProjects";
        public string ProjectData_GetProjectInfo { get; } = "/ProjectData/GetProjectInfo/";
        public string ProjectData_SaveProjectInfo { get; } = "/ProjectData/SaveProjectInfo";


        //ProjectConfigurationData
        public string DbConnectionData_GetAllDbConnections { get; } = "/ProjectConfigurationData/GetAllDbConnections?projectId=";
        public string DbConnectionData_GetDefinition { get; } = "/ProjectConfigurationData/GetDefinition/";
        public string DbConnectionData_SaveConnection { get; } = "/ProjectConfigurationData/SaveConnection/";
        
    }
}
