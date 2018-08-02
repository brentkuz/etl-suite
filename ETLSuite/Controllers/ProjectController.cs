using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETLSuite.Business.Services;
using ETLSuite.Crosscutting;
using ETLSuite.Crosscutting.Enums;
using ETLSuite.Data;
using ETLSuite.Data.Entities;
using ETLSuite.Models;
using ETLSuite.Models.Project;
using Microsoft.AspNetCore.Mvc;
using static ETLSuite.Models.Project.ManageViewModel;

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

            var result = projectService.CreateEmptyProject(name, out id);

            return result ? RedirectToAction("Manage", new { id }) : RedirectToAction("Error", "Home");
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
        public IActionResult GetTab(string tab)
        {
            ManageProjectTab manageProjectTab = (ManageProjectTab)Enum.Parse(typeof(ManageProjectTab), tab);
            var viewName = Constants.TabViewPath + manageProjectTab.ToString() + Constants.PartialViewEnding;
            return PartialView(viewName);
        }

        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}