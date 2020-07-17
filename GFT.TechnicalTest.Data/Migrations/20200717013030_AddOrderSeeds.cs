using GFT.TechnicalTest.Data.Models.Dishes;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable CA1062 // Validate arguments of public methods
#pragma warning disable IDE0058 // Expression value is never used
namespace GFT.TechnicalTest.Data.Migrations
{
    public partial class AddOrderSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var columns = new string[] {
                "Id",
                "Period",
                "DishType",
                "Name",
            };

            var data = new List<Order> {
                new Order{ Id=1, Period = Period.Morning, DishType = DishType.Entree, Name="eggs" },
                new Order{ Id=2, Period = Period.Morning, DishType = DishType.Side, Name="Toast" },
                new Order{ Id=3, Period = Period.Morning, DishType = DishType.Drink, Name="coffee", Multiple = true },

                new Order{ Id=1, Period = Period.Night, DishType = DishType.Entree, Name="steak" },
                new Order{ Id=2, Period = Period.Night, DishType = DishType.Side, Name="potato", Multiple = true },
                new Order{ Id=3, Period = Period.Night, DishType = DishType.Drink, Name="wine" },
                new Order{ Id=4, Period = Period.Night, DishType = DishType.Dessert, Name="cake" }
            };

            var values = data.Select(item => new object[] { item.Id, item.Period, item.DishType, item.Name })
                .ToArray();

            migrationBuilder.InsertData(table: "Order", schema: "Dishes", columns: columns, values: values);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
#pragma warning restore CA1062 // Validate arguments of public methods
#pragma warning restore IDE0058 // Expression value is never used
