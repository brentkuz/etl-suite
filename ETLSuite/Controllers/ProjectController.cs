using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETLSuite.Business.Services;
using ETLSuite.Crosscutting.Enums;
using ETLSuite.Data;
using ETLSuite.Models;
using ETLSuite.Models.Project;
using Microsoft.AspNetCore.Mvc;

namespace ETLSuite.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IMapper mapper;
        private IProjectService projectService;

        public ProjectController(IMapper mapper, IProjectService projectService)
        {
            this.mapper = mapper;
            this.projectService = projectService;
        }
        public IActionResult Index()
        {
            return View();
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
            catch(Exception ex)
            {
                response.Success = false;
                response.Notification = "An error occurred retrieving your projects";
            }

            return Json(response);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Manage()
        {

            return View();
        }
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}