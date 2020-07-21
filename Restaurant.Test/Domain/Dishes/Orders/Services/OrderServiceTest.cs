using Restaurant.Data.Context;
using Restaurant.Data.Models.Dishes;
using Restaurant.Domain.Dishes.Orders.Models;
using Restaurant.Domain.Dishes.Orders.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.UnitTest.Domain.Dishes.Orders.Services
{
    [TestFixture]
    public sealed class OrderServiceTest
    {
        #region Properties
        private Mock<IDataContext> ContextMock { get; set; }

        private OrderService Subject { get; set; }
        #endregion

        #region Setup
        [SetUp]
        public void SetUp()
        {
            this.ContextMock = new Mock<IDataContext>(); ;
            this.Subject = new OrderService(this.ContextMock.Object);
        }
        #endregion

        #region Validations
        [Test]
        public void MakeOrder_Null_Fails()
        {
            CreateOrder payload = null;
            Assert.Throws<ArgumentNullException>(() => this.Subject.MakeOrder(payload));
        }

        [Test]
        public void MakeOrder_Empty_Fails()
        {
            var payload = new CreateOrder { Period = Period.Morning, Dishes = new int[] { } };
            Assert.Throws<ArgumentException>(() => this.Subject.MakeOrder(payload));
        }
        #endregion

        #region Outputs
        [TestCase(Period.Morning, new int[] { 1, 2, 3 }, ExpectedResult = "eggs, toast, coffee")]
        [TestCase(Period.Morning, new int[] { 2, 1, 3 }, ExpectedResult = "eggs, toast, coffee")]
        [TestCase(Period.Morning, new int[] { 1, 2, 3, 4 }, ExpectedResult = "eggs, toast, coffee, error")]
        [TestCase(Period.Morning, new int[] { 1, 2, 3, 3, 3 }, ExpectedResult = "eggs, toast, coffee(x3)")]

        [TestCase(Period.Night, new int[] { 1, 2, 3, 4 }, ExpectedResult = "steak, potato, wine, cake")]
        [TestCase(Period.Night, new int[] { 1, 2, 2, 4 }, ExpectedResult = "steak, potato(x2), cake")]
        [TestCase(Period.Night, new int[] { 1, 2, 3, 5 }, ExpectedResult = "steak, potato, wine, error")]
        [TestCase(Period.Night, new int[] { 1, 1, 2, 3, 5 }, ExpectedResult = "steak, error")]
        public string MakeOrder_Data_Outputs(Period period, int[] dishesData)
        {
            this.MockContextData();
            var payload = new CreateOrder { Period = period, Dishes = dishesData };

            var result = this.Subject.MakeOrder(payload);

            Assert.NotNull(result);
            return result.ToString();
        }
        #endregion

        #region Mock Data
        private void MockContextData()
        {
            var data = new List<Dish> {
                new Dish{ Id=1, Period = Period.Morning, DishType = DishType.Entree, Name="eggs" },
                new Dish{ Id=2, Period = Period.Morning, DishType = DishType.Side, Name="Toast" },
                new Dish{ Id=3, Period = Period.Morning, DishType = DishType.Drink, Name="coffee", Multiple = true },

                new Dish{ Id=1, Period = Period.Night, DishType = DishType.Entree, Name="steak" },
                new Dish{ Id=2, Period = Period.Night, DishType = DishType.Side, Name="potato", Multiple = true },
                new Dish{ Id=3, Period = Period.Night, DishType = DishType.Drink, Name="wine" },
                new Dish{ Id=4, Period = Period.Night, DishType = DishType.Dessert, Name="cake" }
            };

            this.ContextMock.Setup(v => v.Dishes)
                            .Returns(data.AsQueryable());
        }
        #endregion
    }
}
