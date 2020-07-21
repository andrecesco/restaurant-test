using Restaurant.Data.Context.Builders.FrontEnd;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Restaurant.Data.Context.Builders.Dishes
{
    internal static class DishesModelBuilder
    {
        #region Constants
        public const string SchemaName = "Dishes";
        #endregion

        public static EntityTypeBuilder<T> Build<T>(ModelBuilder modelBuilder)
            where T : class, new()
        {
            return BaseModelBuilder.Build<T>(modelBuilder, SchemaName);
        }
    }
}
