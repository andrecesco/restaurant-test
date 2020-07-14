using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GFT.TechnicalTest.Data.Context.Builders.FrontEnd
{
    public static class BaseModelBuilder
    {
        public static EntityTypeBuilder<T> Build<T>(ModelBuilder modelBuilder, string schemaName)
            where T : class, new()
        {
            var builder = modelBuilder?.Entity<T>();
            var type = typeof(T);

            builder.ToTable(type.Name, schemaName);
            return builder;
        }
    }
}
