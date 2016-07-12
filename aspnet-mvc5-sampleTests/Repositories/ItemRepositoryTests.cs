using Microsoft.VisualStudio.TestTools.UnitTesting;
using aspnet_mvc5_sample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using aspnet_mvc5_sample.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using aspnet_mvc5_sampleTests.Data;
using aspnet_mvc5_sample.Data;

namespace aspnet_mvc5_sample.Repositories.Tests
{
    [TestClass()]
    public class ItemRepositoryTests
    {
        [TestMethod()]
        public async Task GetAllAsyncTest()
        {
            var data = new List<Item>
            {
                new Item { ID = 1 ,Title = "Task1" },
                new Item { ID = 2 ,Title = "Task2" },
                new Item { ID = 3 ,Title = "Task3" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Item>>();
            mockSet.As<IDbAsyncEnumerable<Item>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Item>(data.GetEnumerator()));

            mockSet.As<IQueryable<Item>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Item>(data.Provider));

            mockSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Items).Returns(mockSet.Object);

            var repository = new ItemRepository(mockContext.Object);
            var items = await repository.GetAllAsync();
            var result = items.ToList();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Task1", result[0].Title);
            Assert.AreEqual("Task2", result[1].Title);
            Assert.AreEqual("Task3", result[2].Title);

        }

        [TestMethod()]
        public async Task GetByIdAsyncTest()
        {
            var data = new List<Item>
            {
                new Item { ID = 1 ,Title = "Task1" },
                new Item { ID = 2 ,Title = "Task2" },
                new Item { ID = 3 ,Title = "Task3" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Item>>();
            mockSet.As<IDbAsyncEnumerable<Item>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Item>(data.GetEnumerator()));

            mockSet.As<IQueryable<Item>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Item>(data.Provider));

            mockSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Items).Returns(mockSet.Object);


            var repository = new ItemRepository(mockContext.Object);
            var arg = 2;

            var result = await repository.GetByIdAsync(arg);


            Assert.AreEqual(2, result.ID);
            Assert.AreEqual("Task2", result.Title);

        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetByIdAsyncTest_No_Elements()
        {
            var data = new List<Item>
            {
                new Item { ID = 1 ,Title = "Task1" },
                new Item { ID = 2 ,Title = "Task2" },
                new Item { ID = 3 ,Title = "Task3" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Item>>();
            mockSet.As<IDbAsyncEnumerable<Item>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Item>(data.GetEnumerator()));

            mockSet.As<IQueryable<Item>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Item>(data.Provider));

            mockSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Items).Returns(mockSet.Object);


            var repository = new ItemRepository(mockContext.Object);
            var arg = 5;

            var result = await repository.GetByIdAsync(arg);


        }

        [TestMethod()]
        public async Task SaveAsyncTest()
        {
            var data = new List<Item>
            {
                new Item { ID = 1 ,Title = "Task1" },
                new Item { ID = 2 ,Title = "Task2" },
                new Item { ID = 3 ,Title = "Task3" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Item>>();
            mockSet.As<IDbAsyncEnumerable<Item>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Item>(data.GetEnumerator()));

            mockSet.As<IQueryable<Item>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Item>(data.Provider));

            mockSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Items).Returns(mockSet.Object);


            var repository = new ItemRepository(mockContext.Object);

            await repository.SaveAsync(new Item() { Title = "Task4" });

            mockSet.Verify(m => m.Add(It.IsAny<Item>()), Times.Once());
            mockContext.Verify(m => m.SaveChangesAsync(), Times.Once());

        }

        [TestMethod()]
        public async Task UpdateAsyncTest()
        {
            var data = new List<Item>
            {
                new Item { ID = 1 ,Title = "Task1" },
                new Item { ID = 2 ,Title = "Task2" },
                new Item { ID = 3 ,Title = "Task3" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Item>>();
            mockSet.As<IDbAsyncEnumerable<Item>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Item>(data.GetEnumerator()));

            mockSet.As<IQueryable<Item>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Item>(data.Provider));

            mockSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Items).Returns(mockSet.Object);

            var repository = new ItemRepository(mockContext.Object);
            var arg = await repository.GetByIdAsync(1);
            await repository.UpdateAsync(arg);

            mockContext.Verify(m => m.SaveChangesAsync(), Times.Once());

        }

        [TestMethod()]
        public async Task DeleteAsyncTest()
        {
            var data = new List<Item>
            {
                new Item { ID = 1 ,Title = "Task1" },
                new Item { ID = 2 ,Title = "Task2" },
                new Item { ID = 3 ,Title = "Task3" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Item>>();
            mockSet.As<IDbAsyncEnumerable<Item>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Item>(data.GetEnumerator()));

            mockSet.As<IQueryable<Item>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Item>(data.Provider));

            mockSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Items).Returns(mockSet.Object);

            var repository = new ItemRepository(mockContext.Object);
            var arg = 1;

            await repository.DeleteAsync(arg);
            mockSet.Verify(m => m.Remove(It.IsAny<Item>()), Times.Once);
            mockContext.Verify(m => m.SaveChangesAsync(), Times.Once());
        }
    }
}