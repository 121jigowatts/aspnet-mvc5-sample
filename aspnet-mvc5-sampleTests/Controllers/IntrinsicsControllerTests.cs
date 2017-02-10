using Microsoft.VisualStudio.TestTools.UnitTesting;
using aspnet_mvc5_sample.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aspnet_mvc5_sample.Framework;
using Moq;
using System.Web.Mvc;

namespace aspnet_mvc5_sample.Controllers.Tests
{
    [TestClass()]
    public class IntrinsicsControllerTests
    {
        [TestMethod()]
        public void IndexTest_Cached()
        {
            var expected = "Message text";
            var mockCacheService = new Mock<ICacheService>();
            mockCacheService.Setup(m => m["foo"]).Returns(expected);
            var controller = new IntrinsicsController(mockCacheService.Object);

            var result = controller.Index() as ViewResult;
            var actual = result.ViewBag.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IndexTest_NoCache()
        {
            var expected = "Empty";
            var mockCacheService = new Mock<ICacheService>();
            mockCacheService.Setup(m => m["foo"]).Returns(null);
            var controller = new IntrinsicsController(mockCacheService.Object);

            var result = controller.Index() as ViewResult;
            var actual = result.ViewBag.Message;

            Assert.AreEqual(expected, actual);
        }
    }
}