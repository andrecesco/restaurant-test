using GFT.TechnicalTest.Data.Context;
using GFT.TechnicalTest.Data.Models.Dishes;
using GFT.TechnicalTest.Domain.Dishes.Orders.Models;
using GFT.TechnicalTest.Domain.Dishes.Orders.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFT.TechnicalTest.UnitTest.Domain.Dishes.Orders.Services
{
    [TestFixture]
    public sealed class MorningOrderServiceTest
    {
        #region Properties
        private Mock<IDataContext> ContextMock { get; set; }

        private MorningOrderService Subject { get; set; }
        #endregion

        #region Setup
        [SetUp]
        public void SetUp()
        {
            this.ContextMock = new Mock<IDataContext>(); ;
            this.Subject = new MorningOrderService(this.ContextMock.Object);
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
        public void MakeOrder_NightPeriod_Fails()
        {
            var payload = new CreateOrder { Period = Period.Night };
            Assert.Throws<InvalidOperationException>(() => this.Subject.MakeOrder(payload));
        }

        [Test]
        public void MakeOrder_Empty_Fails()
        {
            var payload = new CreateOrder { Period = Period.Morning, Dishes = new int[] { } };
            Assert.Throws<ArgumentException>(() => this.Subject.MakeOrder(payload));
        }
        #endregion

        #region Outputs
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = "eggs, toast, coffee")]
        [TestCase(new int[] { 2, 1, 3 }, ExpectedResult = "eggs, toast, coffee")]
        [TestCase(new int[] { 1, 2, 3, 4 }, ExpectedResult = "eggs, toast, coffee, error")]
        [TestCase(new int[] { 1, 2, 3, 3, 3 }, ExpectedResult = "eggs, toast, coffee(x3)")]
        public string MakeOrder_Data_Outputs(int[] dishesData)
        {
            this.MockContextData();
            var payload = new CreateOrder { Period = Period.Morning, Dishes = dishesData };

            var result = this.Subject.MakeOrder(payload);

            Assert.NotNull(result);
            return result.ToString();
        }
        #endregion

        #region Mock Data
        private void MockContextData()
        {
            var data = new List<Order> {
                new Order{ Id=1, Period = Period.Morning, DishType = DishType.Entree, Name="eggs" },
                new Order{ Id=2, Period = Period.Morning, DishType = DishType.Side, Name="Toast" },
                new Order{ Id=3, Period = Period.Morning, DishType = DishType.Drink, Name="coffee", Multiple = true }
            };

            this.ContextMock.Setup(v => v.Orders)
                            .Returns(data.AsQueryable());
        }
        #endregion
    }
}
