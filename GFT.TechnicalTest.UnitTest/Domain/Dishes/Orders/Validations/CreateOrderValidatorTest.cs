using GFT.TechnicalTest.Data.Models.Dishes;
using GFT.TechnicalTest.Domain.Dishes.Orders.Models;
using GFT.TechnicalTest.Domain.Dishes.Orders.Validations;
using NUnit.Framework;
using System;
using System.Linq;

namespace GFT.TechnicalTest.UnitTest.Domain.Dishes.Orders.Validations
{
    public sealed class CreateOrderValidatorTest
    {
        [Test]
        public void Validate_EmptyPeriod_Fails()
        {
            var validator = new CreateOrderValidator();
            var payload = new CreateOrder
            {
                Dishes = new int[] { 1, 2, 3 }
            };

            var result = validator.Validate(payload);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorCode.Equals("Order-001", StringComparison.InvariantCultureIgnoreCase)));
            Assert.IsTrue(result.Errors.Any(e => e.PropertyName.Equals(nameof(CreateOrder.Period), StringComparison.InvariantCultureIgnoreCase)));
        }

        [Test]
        public void Validate_EmptyDishes_Fails()
        {
            var validator = new CreateOrderValidator();
            var payload = new CreateOrder
            {
                Period = Period.Morning
            };

            var result = validator.Validate(payload);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorCode.Equals("Order-002", StringComparison.InvariantCultureIgnoreCase)));
            Assert.IsTrue(result.Errors.Any(e => e.PropertyName.Equals(nameof(CreateOrder.Dishes), StringComparison.InvariantCultureIgnoreCase)));
        }

        [Test]
        public void Validate_NullDishes_Fails()
        {
            var validator = new CreateOrderValidator();
            var payload = new CreateOrder
            {
                Period = Period.Morning,
                Dishes = null
            };

            var result = validator.Validate(payload);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorCode.Equals("Order-002", StringComparison.InvariantCultureIgnoreCase)));
            Assert.IsTrue(result.Errors.Any(e => e.PropertyName.Equals(nameof(CreateOrder.Dishes), StringComparison.InvariantCultureIgnoreCase)));
        }

        [Test]
        public void Validate_NegativeDishValue_Fails()
        {
            var validator = new CreateOrderValidator();
            var payload = new CreateOrder
            {
                Period = Period.Morning,
                Dishes = new int[] { -1 }
            };

            var result = validator.Validate(payload);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorCode.Equals("Order-002", StringComparison.InvariantCultureIgnoreCase)));
            Assert.IsTrue(result.Errors.Any(e => e.PropertyName.Contains(nameof(CreateOrder.Dishes), StringComparison.InvariantCultureIgnoreCase)));
        }

        [Test]
        public void Validate_ZeroDishValue_Fails()
        {
            var validator = new CreateOrderValidator();
            var payload = new CreateOrder
            {
                Period = Period.Morning,
                Dishes = new int[] { 0 }
            };

            var result = validator.Validate(payload);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorCode.Equals("Order-002", StringComparison.InvariantCultureIgnoreCase)));
            Assert.IsTrue(result.Errors.Any(e => e.PropertyName.Contains(nameof(CreateOrder.Dishes), StringComparison.InvariantCultureIgnoreCase)));
        }

        [Test]
        public void Validate_LargeDishValue_Fails()
        {
            var validator = new CreateOrderValidator();
            var payload = new CreateOrder
            {
                Period = Period.Morning,
                Dishes = new int[] { 4 }
            };

            var result = validator.Validate(payload);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorCode.Equals("Order-002", StringComparison.InvariantCultureIgnoreCase)));
            Assert.IsTrue(result.Errors.Any(e => e.PropertyName.Contains(nameof(CreateOrder.Dishes), StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}
