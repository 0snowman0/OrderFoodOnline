using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    /// <inheritdoc />
    public partial class ChnageString_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_location_Ens_food_Ens_{Food_En_Id}",
                table: "location_Ens");

            migrationBuilder.RenameColumn(
                name: "{Food_En_Id}",
                table: "location_Ens",
                newName: "{Restaurant_En_Id}");

            migrationBuilder.RenameColumn(
                name: "Food_En_Id",
                table: "location_Ens",
                newName: "Restaurant_En_Id");

            migrationBuilder.RenameIndex(
                name: "IX_location_Ens_{Food_En_Id}",
                table: "location_Ens",
                newName: "IX_location_Ens_{Restaurant_En_Id}");

            migrationBuilder.AddColumn<int>(
                name: "restaurant_Id",
                table: "delivery_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "{restaurant_Id}",
                table: "delivery_Ens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Restaurant_En",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    rate = table.Column<int>(type: "int", nullable: false),
                    location_Id = table.Column<int>(type: "int", nullable: false),
                    location_Id0 = table.Column<int>(name: "{location_Id}", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant_En", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurant_En_location_Ens_{location_Id}",
                        column: x => x.location_Id0,
                        principalTable: "location_Ens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_delivery_Ens_{restaurant_Id}",
                table: "delivery_Ens",
                column: "{restaurant_Id}");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_En_{location_Id}",
                table: "Restaurant_En",
                column: "{location_Id}");

            migrationBuilder.AddForeignKey(
                name: "FK_delivery_Ens_Restaurant_En_{restaurant_Id}",
                table: "delivery_Ens",
                column: "{restaurant_Id}",
                principalTable: "Restaurant_En",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_location_Ens_Restaurant_En_{Restaurant_En_Id}",
                table: "location_Ens",
                column: "{Restaurant_En_Id}",
                principalTable: "Restaurant_En",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_delivery_Ens_Restaurant_En_{restaurant_Id}",
                table: "delivery_Ens");

            migrationBuilder.DropForeignKey(
                name: "FK_location_Ens_Restaurant_En_{Restaurant_En_Id}",
                table: "location_Ens");

            migrationBuilder.DropTable(
                name: "Restaurant_En");

            migrationBuilder.DropIndex(
                name: "IX_delivery_Ens_{restaurant_Id}",
                table: "delivery_Ens");

            migrationBuilder.DropColumn(
                name: "restaurant_Id",
                table: "delivery_Ens");

            migrationBuilder.DropColumn(
                name: "{restaurant_Id}",
                table: "delivery_Ens");

            migrationBuilder.RenameColumn(
                name: "{Restaurant_En_Id}",
                table: "location_Ens",
                newName: "{Food_En_Id}");

            migrationBuilder.RenameColumn(
                name: "Restaurant_En_Id",
                table: "location_Ens",
                newName: "Food_En_Id");

            migrationBuilder.RenameIndex(
                name: "IX_location_Ens_{Restaurant_En_Id}",
                table: "location_Ens",
                newName: "IX_location_Ens_{Food_En_Id}");

            migrationBuilder.AddForeignKey(
                name: "FK_location_Ens_food_Ens_{Food_En_Id}",
                table: "location_Ens",
                column: "{Food_En_Id}",
                principalTable: "food_Ens",
                principalColumn: "Id");
        }
    }
}
