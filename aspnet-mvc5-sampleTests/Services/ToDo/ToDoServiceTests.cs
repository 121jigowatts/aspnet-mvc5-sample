using Microsoft.VisualStudio.TestTools.UnitTesting;
using aspnet_mvc5_sample.Services.ToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using aspnet_mvc5_sample.Framework;
using aspnet_mvc5_sample.Repositories.Abstractions;
using aspnet_mvc5_sample.Models;
using aspnet_mvc5_sample.ViewModels.ToDo;

namespace aspnet_mvc5_sample.Services.ToDo.Tests
{
    [TestClass()]
    public class ToDoServiceTests
    {
        [TestMethod()]
        public async Task GetAllAsyncTest_件数確認()
        {
            var retValue = new List<Item>() {
                new Item()
                {
                    ID = 1,
                    Title = "TEST",
                    Description = "TEST",
                    Deadline = new DateTime(2016, 1, 1, 1, 1, 1),
                    Completed = false
                }
            };

            var mockLogger = new Mock<ILogger>();
            var mockRepository = new Mock<IItemRepository>();
            mockRepository.Setup(m => m.GetAllAsync()).ReturnsAsync(retValue);

            var target = new ToDoService(mockLogger.Object, mockRepository.Object);
            var expected = 1;
            var actual = await target.GetAllAsync();


            Assert.AreEqual(expected, actual.ToDoList.Count());
        }

        [TestMethod()]
        public async Task GetByIdAsyncTest()
        {
            var retValue = new Item()
            {
                ID = 1,
                Title = "TEST",
                Description = "TEST",
                Deadline = new DateTime(2016, 1, 1, 1, 1, 1),
                Completed = false
            };

            var mockLogger = new Mock<ILogger>();
            var mockRepository = new Mock<IItemRepository>();
            mockRepository.Setup(m => m.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(retValue);

            var target = new ToDoService(mockLogger.Object, mockRepository.Object);
            var expected = new ItemViewModel()
            {
                ID = 1,
                Title = "TEST",
                Description = "TEST"
            };
            var arg = 1;
            var actual = await target.GetByIdAsync(arg);


            Assert.AreEqual(expected.ID, actual.ID);

        }

        [TestMethod()]
        public async Task CreateAsyncTest()
        {
            var mockLogger = new Mock<ILogger>();
            var mockRepository = new Mock<IItemRepository>();
            mockRepository.Setup(m => m.SaveAsync(It.IsAny<Item>())).Returns(Task.CompletedTask);

            var target = new ToDoService(mockLogger.Object, mockRepository.Object);
            await target.CreateAsync(new ItemViewModel() { ID = 0 });

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public async Task EditAsyncTest()
        {
            var mockLogger = new Mock<ILogger>();
            var mockRepository = new Mock<IItemRepository>();
            mockRepository.Setup(m => m.UpdateAsync(It.IsAny<Item>())).Returns(Task.CompletedTask);

            var target = new ToDoService(mockLogger.Object, mockRepository.Object);
            await target.EditAsync(new ItemViewModel() { ID = 0 });

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public async Task DeleteAsyncTest()
        {
            var mockLogger = new Mock<ILogger>();
            var mockRepository = new Mock<IItemRepository>();
            mockRepository.Setup(m => m.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            var target = new ToDoService(mockLogger.Object, mockRepository.Object);
            await target.DeleteAsync(1);

            Assert.IsTrue(true);
        }
    }
}