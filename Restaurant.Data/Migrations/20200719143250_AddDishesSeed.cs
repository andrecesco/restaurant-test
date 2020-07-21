using Restaurant.Data.Models.Dishes;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable CA1062 // Validate arguments of public methods
#pragma warning disable IDE0058 // Expression value is never used
namespace Restaurant.Data.Migrations
{
    public partial class AddDishesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var columns = new string[] {
                nameof(Dish.Id),
                nameof(Dish.Period),
                nameof(Dish.DishType),
                nameof(Dish.Name),
                nameof(Dish.Multiple)
            };

            var data = new List<Dish> {
                new Dish{ Id=1, Period = Period.Morning, DishType = DishType.Entree, Name="eggs" },
                new Dish{ Id=2, Period = Period.Morning, DishType = DishType.Side, Name="Toast" },
                new Dish{ Id=3, Period = Period.Morning, DishType = DishType.Drink, Name="coffee", Multiple = true },

                new Dish{ Id=1, Period = Period.Night, DishType = DishType.Entree, Name="steak" },
                new Dish{ Id=2, Period = Period.Night, DishType = DishType.Side, Name="potato", Multiple = true },
                new Dish{ Id=3, Period = Period.Night, DishType = DishType.Drink, Name="wine" },
                new Dish{ Id=4, Period = Period.Night, DishType = DishType.Dessert, Name="cake" }
            };

            var values = data.Select(item => new object[] { item.Id, (int)item.Period, (int)item.DishType, item.Name, item.Multiple })
                .ToArray();

            foreach (var value in values)
            {
                migrationBuilder.InsertData(table: "Dish", schema: "Dishes", columns: columns, values: value);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
#pragma warning restore CA1062 // Validate arguments of public methods
#pragma warning restore IDE0058 // Expression value is never used
