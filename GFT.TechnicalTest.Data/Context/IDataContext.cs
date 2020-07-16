using GFT.TechnicalTest.Data.Models.Dishes;
using System.Linq;

namespace GFT.TechnicalTest.Data.Context
{
    public interface IDataContext
    {
        #region Dishes
        public IQueryable<Order> Orders { get; }
        #endregion
    }
}
