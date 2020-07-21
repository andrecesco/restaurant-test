using Restaurant.Domain.Dishes.Orders.Models;

namespace Restaurant.Domain.Dishes.Orders.Services
{
    public interface IOrderService
    {
        SelectOrder MakeOrder(CreateOrder createModel);
    }
}
