using GFT.TechnicalTest.Data.Models.Dishes;
using Microsoft.EntityFrameworkCore;

namespace GFT.TechnicalTest.Data.Context
{
    public interface IDataContext
    {
        #region Dishes
        public DbSet<Order> Orders { get; set; }
        #endregion
    }
}
