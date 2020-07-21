using Restaurant.Data.Models.Dishes;
using Restaurant.Domain.Dishes.Orders.Models;
using Restaurant.Domain.Dishes.Orders.Validations;
using NUnit.Framework;
using System;
using System.Linq;

namespace Restaurant.UnitTest.Domain.Dishes.Orders.Validations
{
    [TestFixture]
    public sealed class CreateOrderValidatorTest
    {
        #region Properties
        private CreateOrderValidator Subject { get; set; }
        #endregion

        #region Setup
        [SetUp]
        public void SetUp()
        {
            this.Subject = new CreateOrderValidator();
        }
        #endregion

        #region Period Validations
        [Test]
        public void Validate_EmptyPeriod_Fails()
        {
            var payload = new CreateOrder
            {
                Dishes = new int[] { 1, 2, 3 }
            };

            var result = this.Subject.Validate(payload);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorCode.Equals("Order-001", StringComparison.InvariantCultureIgnoreCase)));
            Assert.IsTrue(result.Errors.Any(e => e.PropertyName.Equals(nameof(CreateOrder.Period), StringComparison.InvariantCultureIgnoreCase)));
        }
        #endregion

        #region Dishes Validations
        [Test]
        public void Validate_EmptyDishes_Fails()
        {
            var payload = new CreateOrder
            {
                Period = Period.Morning
            };

            var result = this.Subject.Validate(payload);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorCode.Equals("Order-002", StringComparison.InvariantCultureIgnoreCase)));
            Assert.IsTrue(result.Errors.Any(e => e.PropertyName.Equals(nameof(CreateOrder.Dishes), StringComparison.InvariantCultureIgnoreCase)));
        }

        [Test]
        public void Validate_NullDishes_Fails()
        {
            var payload = new CreateOrder
            {
                Period = Period.Morning,
                Dishes = null
            };

            var result = this.Subject.Validate(payload);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorCode.Equals("Order-002", StringComparison.InvariantCultureIgnoreCase)));
            Assert.IsTrue(result.Errors.Any(e => e.PropertyName.Equals(nameof(CreateOrder.Dishes), StringComparison.InvariantCultureIgnoreCase)));
        }
        #endregion
    }
}
