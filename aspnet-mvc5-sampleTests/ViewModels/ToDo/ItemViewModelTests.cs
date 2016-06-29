using Microsoft.VisualStudio.TestTools.UnitTesting;
using aspnet_mvc5_sample.ViewModels.ToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aspnet_mvc5_sample.Models;

namespace aspnet_mvc5_sample.ViewModels.ToDo.Tests
{
    [TestClass()]
    public class ItemViewModelTests
    {
        [TestMethod()]
        public void SetFromModelTest_ID()
        {
            var target = new ItemViewModel();

            var arg = new Item()
            {
                ID = 1
            };
            target.SetFromModel(arg);

            var expected = 1;
            var actual = target.ID;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToModelTest()
        {
            var target = new ItemViewModel() { ID = 1 };

            var expected = new Item() { ID = 1 };

            var actual = target.ConvertToModel();

            Assert.AreEqual(expected.ID, actual.ID);



        }
    }
}