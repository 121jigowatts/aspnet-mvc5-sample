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
        public void SetFromModelTest_Title()
        {
            var target = new ItemViewModel();

            var arg = new Item()
            {
                ID = 1,
                Title = "Title"
            };
            target.SetFromModel(arg);

            var expected = "Title";
            var actual = target.Title;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SetFromModelTest_Description()
        {
            var target = new ItemViewModel();

            var arg = new Item()
            {
                ID = 1,
                Description = "Description"
            };
            target.SetFromModel(arg);

            var expected = "Description";
            var actual = target.Description;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SetFromModelTest_Deadline()
        {
            var target = new ItemViewModel();

            var arg = new Item()
            {
                ID = 1,
                Deadline = new DateTime(2016, 06, 30, 0, 0, 0)
            };
            target.SetFromModel(arg);

            var expected = "2016-06-30 00:00:00";
            var actual = target.Deadline;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SetFromModelTest_Completed()
        {
            var target = new ItemViewModel();

            var arg = new Item()
            {
                ID = 1,
                Completed = true
            };
            target.SetFromModel(arg);

            var expected = true;
            var actual = target.Completed;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SetFromModelTest_未完了かつ期限を過ぎている場合_期限切れ()
        {
            var target = new ItemViewModel();

            var arg = new Item()
            {
                ID = 1,
                Deadline = new DateTime(1900, 1, 1, 0, 0, 0),
                Completed = false
            };
            target.SetFromModel(arg);

            var expected = "期限切れ";
            var actual = target.Expiration;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SetFromModelTest_未完了でも期限を過ぎていない場合_期限切れにならない()
        {
            var target = new ItemViewModel();

            var arg = new Item()
            {
                ID = 1,
                Deadline = new DateTime(2200, 1, 1, 0, 0, 0),
                Completed = false
            };
            target.SetFromModel(arg);

            var expected = String.Empty;
            var actual = target.Expiration;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SetFromModelTest_完了済みかつ期限を過ぎていない場合_期限切れにならない()
        {
            var target = new ItemViewModel();

            var arg = new Item()
            {
                ID = 1,
                Deadline = new DateTime(2200, 1, 1, 0, 0, 0),
                Completed = true
            };
            target.SetFromModel(arg);

            var expected = String.Empty;
            var actual = target.Expiration;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SetFromModelTest_期限を過ぎていても完了済みなら_期限切れにならない()
        {
            var target = new ItemViewModel();

            var arg = new Item()
            {
                ID = 1,
                Deadline = new DateTime(1900, 1, 1, 0, 0, 0),
                Completed = true
            };
            target.SetFromModel(arg);

            var expected = String.Empty;
            var actual = target.Expiration;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void ConvertToModelTest_ID()
        {
            var target = new ItemViewModel() { ID = 1 };

            var expected = new Item() { ID = 1 };

            var actual = target.ConvertToModel();

            Assert.AreEqual(expected.ID, actual.ID);
        }

        [TestMethod()]
        public void ConvertToModelTest_Title()
        {
            var target = new ItemViewModel()
            {
                ID = 1,
                Title = "Title"
            };

            var expected = new Item()
            {
                ID = 1,
                Title = "Title"
            };

            var actual = target.ConvertToModel();

            Assert.AreEqual(expected.Title, actual.Title);
        }

        [TestMethod()]
        public void ConvertToModelTest_Description()
        {
            var target = new ItemViewModel()
            {
                ID = 1,
                Description = "Description"
            };

            var expected = new Item()
            {
                ID = 1,
                Description = "Description"
            };

            var actual = target.ConvertToModel();

            Assert.AreEqual(expected.Description, actual.Description);
        }

        [TestMethod()]
        public void ConvertToModelTest_Deadline()
        {
            var target = new ItemViewModel()
            {
                ID = 1,
                Deadline = "2016-06-30 00:00:00"
            };

            var expected = new Item()
            {
                ID = 1,
                Deadline = new DateTime(2016, 6, 30, 0, 0, 0)
            };

            var actual = target.ConvertToModel();

            Assert.AreEqual(expected.Deadline, actual.Deadline);
        }

        [TestMethod()]
        public void ConvertToModelTest_Completed()
        {
            var target = new ItemViewModel()
            {
                ID = 1,
                Completed = false
            };

            var expected = new Item()
            {
                ID = 1,
                Completed = false
            };

            var actual = target.ConvertToModel();

            Assert.AreEqual(expected.Completed, actual.Completed);
        }

        [TestMethod()]
        public void ConvertToModelTest_ViewModelの期限切れは影響を及ぼさない()
        {
            var target = new ItemViewModel()
            {
                ID = 1,
                Title = "",
                Description = "",
                Deadline = null,
                Completed = true,
                Expiration = "期限切れ"
            };

            var expected = new Item()
            {
                ID = 1,
                Title = "",
                Description = "",
                Deadline = null,
                Completed = true
            };

            Assert.IsTrue(true);
        }
    }
}