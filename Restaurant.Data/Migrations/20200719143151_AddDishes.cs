using Microsoft.EntityFrameworkCore.Migrations;

#pragma warning disable CA1062 // Validate arguments of public methods
#pragma warning disable IDE0058 // Expression value is never used
namespace Restaurant.Data.Migrations
{
    public partial class AddDishes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dishes");

            migrationBuilder.CreateTable(
                name: "Dish",
                schema: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    DishType = table.Column<int>(nullable: false),
                    Multiple = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => new { x.Id, x.Period });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_DishType_Period",
                schema: "Dishes",
                table: "Dish",
                columns: new[] { "DishType", "Period" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dish",
                schema: "Dishes");
        }
    }
}
#pragma warning restore CA1062 // Validate arguments of public methods
#pragma warning restore IDE0058 // Expression value is never used

