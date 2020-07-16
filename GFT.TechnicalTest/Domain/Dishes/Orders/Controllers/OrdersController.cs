using FluentValidation;
using GFT.TechnicalTest.Domain.Dishes.Orders.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GFT.TechnicalTest.Domain.Dishes.Orders.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public sealed class OrdersController : ControllerBase
    {
        private IValidator<CreateOrder> CreateValidator { get; }

        public OrdersController(IValidator<CreateOrder> createValidator)
        {
            this.CreateValidator = createValidator;

        }

        /// <summary>
        /// Creates a new Order and returns the result
        /// </summary>
        /// <param name="createOrder">Order data</param>
        /// <returns>Response to the created Order</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public ActionResult<SelectOrder> MakeOrder([FromBody] CreateOrder createOrder)
        {
            if (createOrder is null)
            {
                return this.BadRequest();
            }

            var validationResult = this.CreateValidator.Validate(createOrder);

            if (!validationResult.IsValid)
            {
                return this.BadRequest(validationResult);
            }

            var result = new SelectOrder
            {
                Data = "teste"
            };

            return this.Ok(result);
        }
    }
}
