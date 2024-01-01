using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    /// <inheritdoc />
    public partial class add_tBL_LOCATION_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "location_Ens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Accuracy = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Food_En_Id = table.Column<int>(type: "int", nullable: false),
                    Food_En_Id0 = table.Column<int>(name: "{Food_En_Id}", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location_Ens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_location_Ens_food_Ens_{Food_En_Id}",
                        column: x => x.Food_En_Id0,
                        principalTable: "food_Ens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_location_Ens_{Food_En_Id}",
                table: "location_Ens",
                column: "{Food_En_Id}",
                unique: true,
                filter: "[{Food_En_Id}] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "location_Ens");
        }
    }
}
