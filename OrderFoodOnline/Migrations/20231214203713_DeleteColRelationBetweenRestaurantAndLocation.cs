using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    /// <inheritdoc />
    public partial class DeleteColRelationBetweenRestaurantAndLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_location_Ens_restaurant_Ens_{Restaurant_En_Id}",
                table: "location_Ens");

            migrationBuilder.DropForeignKey(
                name: "FK_restaurant_Ens_location_Ens_{location_Id}",
                table: "restaurant_Ens");

            migrationBuilder.DropIndex(
                name: "IX_location_Ens_{Restaurant_En_Id}",
                table: "location_Ens");

            migrationBuilder.DropColumn(
                name: "location_Id",
                table: "restaurant_Ens");

            migrationBuilder.DropColumn(
                name: "Restaurant_En_Id",
                table: "location_Ens");

            migrationBuilder.DropColumn(
                name: "{Restaurant_En_Id}",
                table: "location_Ens");

            migrationBuilder.RenameColumn(
                name: "{location_Id}",
                table: "restaurant_Ens",
                newName: "locationId");

            migrationBuilder.RenameIndex(
                name: "IX_restaurant_Ens_{location_Id}",
                table: "restaurant_Ens",
                newName: "IX_restaurant_Ens_locationId");

            migrationBuilder.AddForeignKey(
                name: "FK_restaurant_Ens_location_Ens_locationId",
                table: "restaurant_Ens",
                column: "locationId",
                principalTable: "location_Ens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_restaurant_Ens_location_Ens_locationId",
                table: "restaurant_Ens");

            migrationBuilder.RenameColumn(
                name: "locationId",
                table: "restaurant_Ens",
                newName: "{location_Id}");

            migrationBuilder.RenameIndex(
                name: "IX_restaurant_Ens_locationId",
                table: "restaurant_Ens",
                newName: "IX_restaurant_Ens_{location_Id}");

            migrationBuilder.AddColumn<int>(
                name: "location_Id",
                table: "restaurant_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Restaurant_En_Id",
                table: "location_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "{Restaurant_En_Id}",
                table: "location_Ens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_location_Ens_{Restaurant_En_Id}",
                table: "location_Ens",
                column: "{Restaurant_En_Id}");

            migrationBuilder.AddForeignKey(
                name: "FK_location_Ens_restaurant_Ens_{Restaurant_En_Id}",
                table: "location_Ens",
                column: "{Restaurant_En_Id}",
                principalTable: "restaurant_Ens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_restaurant_Ens_location_Ens_{location_Id}",
                table: "restaurant_Ens",
                column: "{location_Id}",
                principalTable: "location_Ens",
                principalColumn: "Id");
        }
    }
}
