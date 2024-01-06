using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    /// <inheritdoc />
    public partial class AddTblAnalyes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "analyes_Ens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analyes_Ens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productAnalyes_Ens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DateOfSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Analyes_En_Id = table.Column<int>(type: "int", nullable: false),
                    Analyes_En_Id0 = table.Column<int>(name: "{Analyes_En_Id}", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productAnalyes_Ens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productAnalyes_Ens_analyes_Ens_{Analyes_En_Id}",
                        column: x => x.Analyes_En_Id0,
                        principalTable: "analyes_Ens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_productAnalyes_Ens_{Analyes_En_Id}",
                table: "productAnalyes_Ens",
                column: "{Analyes_En_Id}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productAnalyes_Ens");

            migrationBuilder.DropTable(
                name: "analyes_Ens");
        }
    }
}
