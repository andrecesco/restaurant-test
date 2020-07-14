using GFT.TechnicalTest.Domain.Dishes.Orders.Models;
using Swashbuckle.AspNetCore.Filters;

namespace GFT.TechnicalTest.Domain.Dishes.Orders.Controllers.Examples
{
    public sealed class SelectOrderExample : IExamplesProvider<SelectOrder>
    {
        public SelectOrder GetExamples()
        {
            return new SelectOrder
            {
                Data = "eggs, toast, coffee(x3)"
            };
        }
    }
}
