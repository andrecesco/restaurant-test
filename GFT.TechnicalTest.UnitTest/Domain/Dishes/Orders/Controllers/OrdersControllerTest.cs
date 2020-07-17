using FluentValidation;
using FluentValidation.Results;
using GFT.TechnicalTest.Domain.Dishes.Orders.Controllers;
using GFT.TechnicalTest.Domain.Dishes.Orders.Models;
using GFT.TechnicalTest.Domain.Dishes.Orders.Services;
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
            var serviceMock = new Mock<IOrderService>();

            var controller = new OrdersController(validatorMock.Object, serviceMock.Object);

            var response = controller.MakeOrder(payload);

            Assert.IsInstanceOf(typeof(BadRequestResult), response.Result);
        }

        [Test]
        public void MakeOrder_ValidData_CallsServices()
        {
            var payload = new CreateOrder();
            var validatorMock = new Mock<IValidator<CreateOrder>>();
            var serviceMock = new Mock<IOrderService>();

            validatorMock.Setup(v => v.Validate(payload))
                         .Returns(new ValidationResult());

            serviceMock.Setup(v => v.MakeOrder(payload))
                         .Returns(new SelectOrder());

            var controller = new OrdersController(validatorMock.Object, serviceMock.Object);

            var response = controller.MakeOrder(payload);

            validatorMock.VerifyAll();
            serviceMock.VerifyAll();

            Assert.IsInstanceOf(typeof(OkObjectResult), response.Result);
        }
    }
}
