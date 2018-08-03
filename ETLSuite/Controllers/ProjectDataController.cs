//Controller for serving Project data

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETLSuite.Business.Services;
using ETLSuite.Models;
using ETLSuite.Models.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static ETLSuite.Models.Project.ManageViewModel;

namespace ETLSuite.Controllers
{
    public class ProjectDataController : Controller
    {       
        private readonly IMapper mapper;
        private IProjectService projectService;
        private ILogger<ProjectDataController> logger;


        public ProjectDataController(IMapper mapper, IProjectService projectService, ILogger<ProjectDataController> logger)
        {
            this.mapper = mapper;
            this.projectService = projectService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            var response = new JsonResponse();
            try
            {
                var projects = projectService.GetAll();
                var vms = new List<ProjectSummaryViewModel>();

                foreach (var proj in projects)
                    vms.Add(mapper.Map<ProjectSummaryViewModel>(proj));

                response.Data = vms;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Notification = "An error occurred retrieving your projects";
                logger.LogError(ex, response.Notification);
            }

            return Json(response);
        }

        [HttpGet]
        public IActionResult GetProjectInfo(int id)
        {
            var response = new JsonResponse();
            try
            {
                var project = projectService.GetById(id);
                response.Data = mapper.Map<ProjectInfoViewModel>(project);
                response.Success = project != null;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Notification = "An error occurred retrieving your project";
                logger.LogError(ex, response.Notification);
            }

            return Json(response);
        }

    }
}