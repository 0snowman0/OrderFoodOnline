using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    /// <inheritdoc />
    public partial class AddRblRDeliveryAndRestaurant_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_delivery_Ens_Restaurant_En_{restaurant_Id}",
                table: "delivery_Ens");

            migrationBuilder.DropColumn(
                name: "restaurant_Id",
                table: "delivery_Ens");

            migrationBuilder.RenameColumn(
                name: "{restaurant_Id}",
                table: "delivery_Ens",
                newName: "{Delivery_Id}");

            migrationBuilder.RenameIndex(
                name: "IX_delivery_Ens_{restaurant_Id}",
                table: "delivery_Ens",
                newName: "IX_delivery_Ens_{Delivery_Id}");

            migrationBuilder.AddColumn<int>(
                name: "{Restaurant_Id}",
                table: "Restaurant_En",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "delivery_Restaurant_Relation_Ens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant_Id = table.Column<int>(type: "int", nullable: false),
                    Delivery_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_Restaurant_Relation_Ens", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_En_{Restaurant_Id}",
                table: "Restaurant_En",
                column: "{Restaurant_Id}");

            migrationBuilder.AddForeignKey(
                name: "FK_delivery_Ens_delivery_Restaurant_Relation_Ens_{Delivery_Id}",
                table: "delivery_Ens",
                column: "{Delivery_Id}",
                principalTable: "delivery_Restaurant_Relation_Ens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_En_delivery_Restaurant_Relation_Ens_{Restaurant_Id}",
                table: "Restaurant_En",
                column: "{Restaurant_Id}",
                principalTable: "delivery_Restaurant_Relation_Ens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_delivery_Ens_delivery_Restaurant_Relation_Ens_{Delivery_Id}",
                table: "delivery_Ens");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_En_delivery_Restaurant_Relation_Ens_{Restaurant_Id}",
                table: "Restaurant_En");

            migrationBuilder.DropTable(
                name: "delivery_Restaurant_Relation_Ens");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_En_{Restaurant_Id}",
                table: "Restaurant_En");

            migrationBuilder.DropColumn(
                name: "{Restaurant_Id}",
                table: "Restaurant_En");

            migrationBuilder.RenameColumn(
                name: "{Delivery_Id}",
                table: "delivery_Ens",
                newName: "{restaurant_Id}");

            migrationBuilder.RenameIndex(
                name: "IX_delivery_Ens_{Delivery_Id}",
                table: "delivery_Ens",
                newName: "IX_delivery_Ens_{restaurant_Id}");

            migrationBuilder.AddColumn<int>(
                name: "restaurant_Id",
                table: "delivery_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_delivery_Ens_Restaurant_En_{restaurant_Id}",
                table: "delivery_Ens",
                column: "{restaurant_Id}",
                principalTable: "Restaurant_En",
                principalColumn: "Id");
        }
    }
}
