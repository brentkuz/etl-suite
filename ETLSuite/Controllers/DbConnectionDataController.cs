using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETLSuite.Business.Objects;
using ETLSuite.Business.Services;
using ETLSuite.Crosscutting.Enums;
using ETLSuite.Models;
using ETLSuite.Models.Factories;
using ETLSuite.Models.Project;
using ETLSuite.Models.Project.Tabs.DbConnection;
using ETLSuite.Models.Project.Tabs.EditModals.DbConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETLSuite.Controllers
{
    public class DbConnectionDataController : BaseController<DbConnectionDataController>
    {
        private IDbConnectionDefinitionService connectionService;
        private IDbConnectionDefinitionViewModelFactory vmFactory;

        public DbConnectionDataController(IMapper mapper, ILogger<DbConnectionDataController> logger, IDbConnectionDefinitionService connectionService, IDbConnectionDefinitionViewModelFactory vmFactory) : base(mapper, logger)
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
                response.Data = vmFactory.GetViewModel(connectionService.GetById(id));
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Notification = "An error occurred retrieving the Db Connection.";
                logger.LogError(ex, response.Notification);
            }
            return Json(response);
        }

        [HttpPost]
        public IActionResult SaveSqlServerConnection(SqlServerConnectionDefinitionViewModel vm)
        {
            var response = new JsonResponse();
            try
            {
                response.Success = connectionService.SaveSqlServerConnection(mapper.Map<SqlServerConnectionDefinition>(vm));
                if(!response.Success)
                {
                    response.Notification = "An error occurred saving your changes.";
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Notification = "An error occurred saving your changes.";
                logger.LogError(ex, response.Notification);
            }

            return Json(response);
        }
    }
}