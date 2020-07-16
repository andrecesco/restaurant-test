using FluentValidation;
using FluentValidation.Results;
using GFT.TechnicalTest.Domain.Dishes.Orders.Controllers;
using GFT.TechnicalTest.Domain.Dishes.Orders.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace GFT.TechnicalTest.UnitTest.Domain.Dishes.Orders.Controllers
{
    public sealed class OrdersControllerTest
    {
        [Test]
        public void MakeOrder_Empty_Fails()
        {
            CreateOrder payload = null;
            var validatorMock = new Mock<IValidator<CreateOrder>>();

            var controller = new OrdersController(validatorMock.Object);

            var response = controller.MakeOrder(payload);

            Assert.IsInstanceOf(typeof(BadRequestResult), response.Result);
        }

        [Test]
        public void MakeOrder_ValidData_CallsValidator()
        {
            var payload = new CreateOrder();
            var validatorMock = new Mock<IValidator<CreateOrder>>();

            validatorMock.Setup(v => v.Validate(payload))
                         .Returns(new ValidationResult());

            var controller = new OrdersController(validatorMock.Object);

            var response = controller.MakeOrder(payload);

            validatorMock.VerifyAll();
            Assert.IsInstanceOf(typeof(OkObjectResult), response.Result);
        }
    }
}
