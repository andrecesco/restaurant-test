using Restaurant.Data.Models.Dishes;
using Restaurant.Domain.Dishes.Orders.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace Restaurant.Domain.Dishes.Orders.Controllers.Examples
{
    public sealed class CreateOrderExample : IExamplesProvider<CreateOrder>
    {
        public CreateOrder GetExamples()
        {
            return new CreateOrder
            {
                Period = Period.Morning,
                Dishes = new List<int> {
                    1,2,3,3,3
                }
            };
        }
    }
}
