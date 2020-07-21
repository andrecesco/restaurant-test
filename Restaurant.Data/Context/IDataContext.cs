using Restaurant.Data.Models.Dishes;
using System.Linq;

namespace Restaurant.Data.Context
{
    public interface IDataContext
    {
        #region Dishes
        public IQueryable<Dish> Dishes { get; }
        #endregion
    }
}
