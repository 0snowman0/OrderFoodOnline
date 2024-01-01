using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEnAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "restaurant_Id",
                table: "food_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "{restaurant_Id}",
                table: "food_Ens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_food_Ens_{restaurant_Id}",
                table: "food_Ens",
                column: "{restaurant_Id}");

            migrationBuilder.AddForeignKey(
                name: "FK_food_Ens_Restaurant_En_{restaurant_Id}",
                table: "food_Ens",
                column: "{restaurant_Id}",
                principalTable: "Restaurant_En",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_food_Ens_Restaurant_En_{restaurant_Id}",
                table: "food_Ens");

            migrationBuilder.DropIndex(
                name: "IX_food_Ens_{restaurant_Id}",
                table: "food_Ens");

            migrationBuilder.DropColumn(
                name: "restaurant_Id",
                table: "food_Ens");

            migrationBuilder.DropColumn(
                name: "{restaurant_Id}",
                table: "food_Ens");
        }
    }
}
