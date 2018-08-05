//Controller for serving Project Views

using System;
using AutoMapper;
using ETLSuite.Business.Services;
using ETLSuite.Crosscutting;
using ETLSuite.Crosscutting.Enums;
using ETLSuite.Data.Entities;
using ETLSuite.Models.Project;
using Microsoft.AspNetCore.Mvc;
using static ETLSuite.Models.Project.ManageViewModel;

namespace ETLSuite.Controllers
{
    public class ProjectController : BaseController
    {        
        private IProjectService projectService;

        public ProjectController(IMapper mapper, IProjectService projectService) : base(mapper)
        {
            this.projectService = projectService;
        }

        public IActionResult Index()
        {
            return View(new IndexViewModel());
        }

        [HttpGet]
        public IActionResult Create(string name)
        {
            var project = new Project
            {
                Name = name
            };

            int id;
            
            return projectService.CreateEmptyProject(name, out id) 
                ? RedirectToAction("Manage", new { id }) 
                : RedirectToAction("Error", "Home");
        }

        public IActionResult Manage(int id)
        {
            var vm = new ManageViewModel()
            {
                ProjectId = id,
                CurrentTab = ManageProjectTab.ProjectInfo
            };
            return View(vm);
        }
        public IActionResult GetTabTemplate(string tab)
        {
            ManageProjectTab manageProjectTab = (ManageProjectTab)Enum.Parse(typeof(ManageProjectTab), tab);
            var viewName = Constants.TabViewPath + manageProjectTab.ToString() + Constants.PartialViewEnding;
            return PartialView(viewName);
        }

        public IActionResult GetConfigurationEditTemplate(string type)
        {
            ConfigurationEditType configTab = (ConfigurationEditType)Enum.Parse(typeof(ConfigurationEditType), type);
            var viewName = Constants.ConfigurationEditModalViewPath + configTab.ToString() + Constants.PartialViewEnding;
            return PartialView(viewName);
        }

        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}