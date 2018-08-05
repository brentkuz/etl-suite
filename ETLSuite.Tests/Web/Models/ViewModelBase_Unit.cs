using ETLSuite.Models.Project;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ETLSuite.Models;
using static ETLSuite.Models.Project.ManageViewModel;

namespace ETLSuite.Tests.Web.Models
{
    [TestClass]
    public class ViewModelBase_Unit
    {
        [TestMethod]
        [TestCategory("ViewModelBase_Unit")]
        public void GetUrls_SuccessfullySerializesFields()
        {
            var vm = new ViewModelBase();
            var urlCnt = typeof(UrlConstants).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Length;

            var res = vm.GetUrls();
            
            var resCnt = ((JObject)JsonConvert.DeserializeObject(res)).Count;

            Assert.IsNotNull(res);
            Assert.AreEqual(urlCnt, resCnt);
        }

        [TestMethod]
        [TestCategory("ViewModelBase_Unit")]
        public void GetClientConfig_SuccessfullySerializesFields()
        {
            var vm = new ManageViewModel()
            {
                ProjectId = 1,
                CurrentTab = ManageProjectTab.ProjectInfo
            };
            //var urlCnt = typeof(UrlConstants).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Length;

            var res = vm.GetClientConfig();

            //var resCnt = ((JObject)JsonConvert.DeserializeObject(res)).Count;

            Assert.IsNotNull(res);
            //Assert.AreEqual(urlCnt, resCnt);
        }
    }
}
