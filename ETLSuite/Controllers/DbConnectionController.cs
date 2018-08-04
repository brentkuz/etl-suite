﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETLSuite.Business.Services;
using ETLSuite.Models;
using ETLSuite.Models.Project;
using Microsoft.AspNetCore.Mvc;

namespace ETLSuite.Controllers
{
    public class DbConnectionController : BaseController
    {
        private IDbConnectionDefinitionService connectionService;

        public DbConnectionController(IMapper mapper, IDbConnectionDefinitionService connectionService) : base(mapper)
        {
            this.connectionService = connectionService;
        }

        [HttpGet]
        public IActionResult Index(int projectId)
        {
            var response = new JsonResponse();
            var definitions = connectionService.GetByProjectId(projectId);
            var vms = new List<DbConnectionDefinitionSummaryViewModel>();
            foreach (var def in definitions)
                vms.Add(mapper.Map<DbConnectionDefinitionSummaryViewModel>(def));

            response.Data = vms;

            return Json(response);
        }
    }
}