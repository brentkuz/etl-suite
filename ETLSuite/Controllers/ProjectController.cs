using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETLSuite.Crosscutting.Enums;
using ETLSuite.Data;
using ETLSuite.Models.Project;
using Microsoft.AspNetCore.Mvc;

namespace ETLSuite.Controllers
{
    public class ProjectController : Controller
    {
        private List<ProjectSummaryViewModel> projects = new List<ProjectSummaryViewModel>
        {
            new ProjectSummaryViewModel
            {
                Id = 1,
                Name = "Project 1",
                Description = "Project 1 Description",
                Status = ProjectStatus.Enabled
            }
        };

        public ProjectController(ETLDataContext context)
        {
            var ctx = context;
        }
        public IActionResult Index()
        {
            return View(projects);
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