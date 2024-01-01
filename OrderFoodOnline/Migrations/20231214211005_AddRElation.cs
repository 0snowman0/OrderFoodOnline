using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    /// <inheritdoc />
    public partial class AddRElation : Migration
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
                name: "IX_restaurant_Ens_{location_Id}",
                table: "restaurant_Ens");

            migrationBuilder.DropIndex(
                name: "IX_location_Ens_{Restaurant_En_Id}",
                table: "location_Ens");

            migrationBuilder.DropColumn(
                name: "location_Id",
                table: "restaurant_Ens");

            migrationBuilder.DropColumn(
                name: "{location_Id}",
                table: "restaurant_Ens");

            migrationBuilder.DropColumn(
                name: "Restaurant_En_Id",
                table: "location_Ens");

            migrationBuilder.DropColumn(
                name: "{Restaurant_En_Id}",
                table: "location_Ens");

            migrationBuilder.CreateTable(
                name: "location_Restaurant_Relation_Ens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location_Id = table.Column<int>(type: "int", nullable: false),
                    restaurant_Id = table.Column<int>(type: "int", nullable: false),
                    restaurant_Id0 = table.Column<int>(name: "{restaurant_Id}", type: "int", nullable: true),
                    location_Id0 = table.Column<int>(name: "{location_Id}", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location_Restaurant_Relation_Ens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_location_Restaurant_Relation_Ens_location_Ens_{location_Id}",
                        column: x => x.location_Id0,
                        principalTable: "location_Ens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_location_Restaurant_Relation_Ens_restaurant_Ens_{restaurant_Id}",
                        column: x => x.restaurant_Id0,
                        principalTable: "restaurant_Ens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_location_Restaurant_Relation_Ens_{location_Id}",
                table: "location_Restaurant_Relation_Ens",
                column: "{location_Id}");

            migrationBuilder.CreateIndex(
                name: "IX_location_Restaurant_Relation_Ens_{restaurant_Id}",
                table: "location_Restaurant_Relation_Ens",
                column: "{restaurant_Id}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "location_Restaurant_Relation_Ens");

            migrationBuilder.AddColumn<int>(
                name: "location_Id",
                table: "restaurant_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "{location_Id}",
                table: "restaurant_Ens",
                type: "int",
                nullable: true);

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
                name: "IX_restaurant_Ens_{location_Id}",
                table: "restaurant_Ens",
                column: "{location_Id}");

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
