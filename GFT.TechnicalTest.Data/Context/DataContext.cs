using GFT.TechnicalTest.Data.Context.Builders.Dishes;
using GFT.TechnicalTest.Data.Models.Dishes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GFT.TechnicalTest.Data.Context
{
    public sealed class DataContext : DbContext, IDataContext
    {
        #region Dishes
        private DbSet<Order> OrdersSet { get; set; }

        public IQueryable<Order> Orders => this.OrdersSet;
        #endregion

        #region Constructors
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }
        #endregion

        #region Overloads
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.BuildOrder();
        }
        #endregion
    }
}
