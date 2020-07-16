using GFT.TechnicalTest.Data.Models.Dishes;
using Microsoft.EntityFrameworkCore;

namespace GFT.TechnicalTest.Data.Context.Builders.Dishes
{
    public static class OrderBuilder
    {
        public static ModelBuilder BuildOrder(this ModelBuilder modelBuilder)
        {
            var builder = DishesModelBuilder.Build<Order>(modelBuilder);

            builder.HasKey(m => m.Id);

            builder.Property(p => p.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(p => p.DishType)
                   .IsRequired();

            builder.Property(p => p.Period)
                   .IsRequired();

            builder.Property(p => p.Multiple)
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.Property(p => p.Name)
                   .HasMaxLength(6)
                   .IsRequired();

            builder.HasIndex(m => new { m.DishType, m.Period })
                   .IsUnique();

            return modelBuilder;
        }
    }
}
