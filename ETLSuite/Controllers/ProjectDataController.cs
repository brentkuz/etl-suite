//Controller for serving Project data

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETLSuite.Business.Services;
using ETLSuite.Data.Entities;
using ETLSuite.Models;
using ETLSuite.Models.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static ETLSuite.Models.Project.ManageViewModel;

namespace ETLSuite.Controllers
{
    public class ProjectDataController : BaseController
    {       
        private IProjectService projectService;
        private ILogger<ProjectDataController> logger;


        public ProjectDataController(IMapper mapper, IProjectService projectService, ILogger<ProjectDataController> logger) : base(mapper)
        {
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
                response.Notification = "An error occurred retrieving your projects.";
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
                response.Notification = "An error occurred retrieving your project.";
                logger.LogError(ex, response.Notification);
            }

            return Json(response);
        }

        [HttpPost]
        public IActionResult SaveProjectInfo(ProjectInfoViewModel vm)
        {
            var response = new JsonResponse();
            try
            {
                if (ModelState.IsValid)
                {
                    var project = mapper.Map<Project>(vm);                    

                    response.Success = projectService.UpdateProjectInfo(project);
                    if (!response.Success)
                    {
                        response.Notification = "An error occurred saving your changes";
                        var refresh = projectService.GetById(vm.Id);
                        if (refresh != null)
                            response.Data = mapper.Map<ProjectInfoViewModel>(refresh);
                    }
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