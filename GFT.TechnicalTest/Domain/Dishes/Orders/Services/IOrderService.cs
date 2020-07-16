using GFT.TechnicalTest.Domain.Dishes.Orders.Models;

namespace GFT.TechnicalTest.Domain.Dishes.Orders.Services
{
    public interface IOrderService
    {
        SelectOrder MakeOrder(CreateOrder createModel);
    }
}
