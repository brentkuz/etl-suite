using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETLSuite.Business.Services;
using ETLSuite.Models;
using ETLSuite.Models.Factories;
using ETLSuite.Models.Project;
using ETLSuite.Models.Project.Tabs.DbConnection;
using ETLSuite.Models.Project.Tabs.EditModals.DbConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETLSuite.Controllers
{
    public class ProjectConfigurationDataController : BaseController<ProjectConfigurationDataController>
    {
        private IDbConnectionDefinitionService connectionService;
        private IDbConnectionDefinitionViewModelFactory vmFactory;

        public ProjectConfigurationDataController(IMapper mapper, ILogger<ProjectConfigurationDataController> logger, IDbConnectionDefinitionService connectionService, IDbConnectionDefinitionViewModelFactory vmFactory) : base(mapper, logger)
        {
            this.connectionService = connectionService;
            this.vmFactory = vmFactory;
        }

        [HttpGet]
        public IActionResult GetAllDbConnections(int projectId)
        {
            var response = new JsonResponse();
            try
            {               
                var definitions = connectionService.GetAllByProjectId(projectId);
                var vms = new List<DbConnectionDefinitionSummaryViewModel>();
                foreach (var def in definitions)
                    vms.Add(mapper.Map<DbConnectionDefinitionSummaryViewModel>(def));

                response.Data = vms;

                
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Notification = "An error occurred retrieving the Db Connections.";
                logger.LogError(ex, response.Notification);
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult GetDefinition(int id)
        {
            var response = new JsonResponse();
            try
            {
                var definition = connectionService.GetById(id);

                response.Data = vmFactory.GetViewModel(definition);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Notification = "An error occurred retrieving the Db Connection.";
                logger.LogError(ex, response.Notification);
            }
            return Json(response);
        }
    }
}