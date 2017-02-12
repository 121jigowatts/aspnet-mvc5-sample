using Microsoft.VisualStudio.TestTools.UnitTesting;
using aspnet_mvc5_sample.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using aspnet_mvc5_sample.Framework;
using System.Web.Mvc;

namespace aspnet_mvc5_sample.Controllers.Tests
{
    [TestClass()]
    public class StartControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var expected = "2017/02/10 15:31:01.002";
            var mockCacheService = new Mock<ICacheService>();
            var dt = new DateTime(2017,2, 10, 15, 31, 1, 2);
            mockCacheService.Setup(m => m["StartTime"]).Returns(dt);

            MvcApplication.RegisterCacheService(mockCacheService.Object);
            var controller = new StartController();
            var result = controller.Index() as ViewResult;

            var actual = result.ViewBag.StartTime;

            Assert.AreEqual(expected, actual);
        }
    }
}