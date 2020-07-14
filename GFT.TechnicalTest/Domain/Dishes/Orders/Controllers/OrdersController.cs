using GFT.TechnicalTest.Domain.Dishes.Orders.Models;
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
        /// <summary>
        /// Creates a new Order and returns the result
        /// </summary>
        /// <param name="createOrder">Order data</param>
        /// <returns>Response to the created Order</returns>
        [HttpPost]
        public ActionResult<SelectOrder> SelectOrders([FromBody] CreateOrder createOrder)
        {
            var result = new SelectOrder
            {
                Data = "teste"
            };

            return this.Ok(result);
        }
    }
}
