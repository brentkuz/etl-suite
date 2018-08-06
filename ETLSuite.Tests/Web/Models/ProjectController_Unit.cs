using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using ETLSuite.Controllers;
using AutoMapper;
using ETLSuite.Business.Services;
using static ETLSuite.Models.Project.ManageViewModel;
using Microsoft.AspNetCore.Mvc;
using ETLSuite.Crosscutting.Enums;
using Microsoft.Extensions.Logging;

namespace ETLSuite.Tests.Web.Models
{
    [TestClass]
    [TestCategory("ProjectController_Unit")]
    public class ProjectController_Unit
    {
        [TestMethod]
        public void GetTabTemplate_ResolvesCorrectTemplate()
        {
            var mapperMock = new Mock<IMapper>();
            var projectServiceMock = new Mock<IProjectService>();
            var logMock = new Mock<ILogger<ProjectController>>();
            var ctrl = new ProjectController(mapperMock.Object, projectServiceMock.Object, logMock.Object);

            var toGet = ManageProjectTab.ProjectInfo;

            var res = ctrl.GetTabTemplate(toGet) as PartialViewResult;

            Assert.AreEqual("~/Views/Project/Tabs/ProjectInfoPartial.cshtml", res.ViewName);
        }

        [TestMethod]
        public void GetDbConnectionEditTemplate_ResolvesCorrectTemplate()
        {
            var mapperMock = new Mock<IMapper>();
            var projectServiceMock = new Mock<IProjectService>();
            var logMock = new Mock<ILogger<ProjectController>>();
            var ctrl = new ProjectController(mapperMock.Object, projectServiceMock.Object, logMock.Object);

            var toGet = DatabaseType.SqlServer;

            var res = ctrl.GetDbConnectionEditTemplate(toGet) as PartialViewResult;

            Assert.AreEqual("~/Views/Project/Tabs/EditModals/DbConnection/SqlServerConnectionEditPartial.cshtml", res.ViewName);
        }
    }
}
