using Restaurant.Domain.Dishes.Orders.Models;

namespace Restaurant.Domain.Dishes.Orders.Services
{
    /// <summary>
    /// Handles all operations over <see cref="Dish"/> orders
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Makes an order based on the input
        /// </summary>
        /// <param name="createModel">Order input</param>
        /// <returns>Processed order</returns>
        SelectOrder MakeOrder(CreateOrder createModel);
    }
}
