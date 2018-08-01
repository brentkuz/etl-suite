using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETLSuite.Business.Services;
using ETLSuite.Models;
using ETLSuite.Models.Project;
using Microsoft.AspNetCore.Mvc;
using static ETLSuite.Models.Project.ManageProjectViewModel;

namespace ETLSuite.Controllers
{
    public class ProjectDataController : Controller
    {       
        private readonly IMapper mapper;
        private IProjectService projectService;


        public ProjectDataController(IMapper mapper, IProjectService projectService)
        {
            this.mapper = mapper;
            this.projectService = projectService;
        }

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
            }

            return Json(response);
        }


    }
}