using FluentValidation;
using Restaurant.Domain.Dishes.Orders.Models;
using Restaurant.Domain.Dishes.Orders.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Domain.Dishes.Orders.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public sealed class OrdersController : ControllerBase
    {
        #region Properties
        private IValidator<CreateOrder> CreateValidator { get; }

        private IOrderService OrderService { get; }
        #endregion

        #region Constructors
        public OrdersController(IValidator<CreateOrder> createValidator,
            IOrderService orderService)
        {
            this.CreateValidator = createValidator;
            this.OrderService = orderService;
        }
        #endregion

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

            var result = this.OrderService.MakeOrder(createOrder);
            return this.Ok(result);
        }
    }
}
