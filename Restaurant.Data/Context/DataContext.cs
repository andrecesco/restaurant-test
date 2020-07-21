using Restaurant.Data.Context.Builders.Dishes;
using Restaurant.Data.Models.Dishes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Restaurant.Data.Context
{
    public sealed class DataContext : DbContext, IDataContext
    {
        #region Dishes
        private DbSet<Dish> DishSet { get; set; }

        public IQueryable<Dish> Dishes => this.DishSet;
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
            modelBuilder.BuildDish();
        }
        #endregion
    }
}
