using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETLSuite.Data;
using Microsoft.AspNetCore.Mvc;

namespace ETLSuite.Controllers
{
    public class ProjectController : Controller
    {
        public ProjectController(ETLDataContext context)
        {
            var ctx = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}