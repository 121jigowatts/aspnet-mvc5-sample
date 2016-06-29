using Microsoft.VisualStudio.TestTools.UnitTesting;
using aspnet_mvc5_sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_sample.Models.Tests
{
    [TestClass()]
    public class ItemTests
    {
        [TestMethod()]
        public void ExpirationTest_DeadlineがNullの場合falseを返す()
        {
            var target = new Item()
            {
                ID = 1,
                Title = "TEST-Title",
                Description = "TEST-Description",
                Deadline = null,
                Completed = false
            };

            var expected = false;
            var actual = target.IsExpiration();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExpirationTest_Completedがtrueの場合falseを返す()
        {
            var target = new Item()
            {
                ID = 1,
                Title = "TEST-Title",
                Description = "TEST-Description",
                Deadline = null,
                Completed = true
            };

            var expected = false;
            var actual = target.IsExpiration();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExpirationTest_Deadlineが現在日時より前の場合falseを返す()
        {
            var target = new Item()
            {
                ID = 1,
                Title = "TEST-Title",
                Description = "TEST-Description",
                Deadline = new DateTime(2016, 6, 27, 0, 0, 1),
                Completed = false
            };

            var expected = false;
            var now = new DateTime(2016, 6, 27, 0, 0, 0);
            var actual = target.IsExpiration(now);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExpirationTest_Deadlineが現在日時を過ぎた場合trueを返す()
        {
            var target = new Item()
            {
                ID = 1,
                Title = "TEST-Title",
                Description = "TEST-Description",
                Deadline = new DateTime(2016, 6, 27, 0, 0, 0),
                Completed = false
            };

            var expected = true;
            var now = new DateTime(2016, 6, 27, 0, 0, 1);
            var actual = target.IsExpiration(now);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExpirationTest_Deadlineと現在日時が同値場合trueを返す()
        {
            var target = new Item()
            {
                ID = 1,
                Title = "TEST-Title",
                Description = "TEST-Description",
                Deadline = new DateTime(2016, 6, 27, 0, 0, 1),
                Completed = false
            };

            var expected = true;
            var now = new DateTime(2016, 6, 27, 0, 0, 1);
            var actual = target.IsExpiration(now);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExpirationTest_完了済みかつDeadlineが現在日時を過ぎた場合falseを返す()
        {
            var target = new Item()
            {
                ID = 1,
                Title = "TEST-Title",
                Description = "TEST-Description",
                Deadline = new DateTime(2016, 6, 27, 0, 0, 0),
                Completed = true
            };

            var expected = false;
            var now = new DateTime(2016, 6, 27, 0, 0, 1);
            var actual = target.IsExpiration(now);

            Assert.AreEqual(expected, actual);
        }
    }
}