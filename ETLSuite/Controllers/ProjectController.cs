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
using static ETLSuite.Models.Project.ManageViewModel;

namespace ETLSuite.Controllers
{
    public class ProjectController : Controller
    {
        private const string TabViewPath = "~/Views/Project/Tabs/";
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


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Manage(int? id)
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
            var viewName = TabViewPath + manageProjectTab.ToString() + "Partial.cshtml";
            return PartialView(viewName);
        }

        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}