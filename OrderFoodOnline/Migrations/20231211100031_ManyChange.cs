using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    /// <inheritdoc />
    public partial class ManyChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_delivery_Ens_delivery_Restaurant_Relation_Ens_{Delivery_Id}",
                table: "delivery_Ens");

            migrationBuilder.DropForeignKey(
                name: "FK_food_Ens_Restaurant_En_{restaurant_Id}",
                table: "food_Ens");

            migrationBuilder.DropForeignKey(
                name: "FK_location_Ens_Restaurant_En_{Restaurant_En_Id}",
                table: "location_Ens");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_En_delivery_Restaurant_Relation_Ens_{Restaurant_Id}",
                table: "Restaurant_En");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_En_location_Ens_{location_Id}",
                table: "Restaurant_En");

            migrationBuilder.DropIndex(
                name: "IX_delivery_Ens_{Delivery_Id}",
                table: "delivery_Ens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurant_En",
                table: "Restaurant_En");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_En_{Restaurant_Id}",
                table: "Restaurant_En");

            migrationBuilder.DropColumn(
                name: "{Delivery_Id}",
                table: "delivery_Ens");

            migrationBuilder.DropColumn(
                name: "{Restaurant_Id}",
                table: "Restaurant_En");

            migrationBuilder.RenameTable(
                name: "Restaurant_En",
                newName: "restaurant_Ens");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_En_{location_Id}",
                table: "restaurant_Ens",
                newName: "IX_restaurant_Ens_{location_Id}");

            migrationBuilder.AddColumn<int>(
                name: "{Delivery_Id}",
                table: "delivery_Restaurant_Relation_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "{Restaurant_Id}",
                table: "delivery_Restaurant_Relation_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_restaurant_Ens",
                table: "restaurant_Ens",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_Restaurant_Relation_Ens_{Delivery_Id}",
                table: "delivery_Restaurant_Relation_Ens",
                column: "{Delivery_Id}");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_Restaurant_Relation_Ens_{Restaurant_Id}",
                table: "delivery_Restaurant_Relation_Ens",
                column: "{Restaurant_Id}");

            migrationBuilder.AddForeignKey(
                name: "FK_delivery_Restaurant_Relation_Ens_delivery_Ens_{Delivery_Id}",
                table: "delivery_Restaurant_Relation_Ens",
                column: "{Delivery_Id}",
                principalTable: "delivery_Ens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_delivery_Restaurant_Relation_Ens_restaurant_Ens_{Restaurant_Id}",
                table: "delivery_Restaurant_Relation_Ens",
                column: "{Restaurant_Id}",
                principalTable: "restaurant_Ens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_food_Ens_restaurant_Ens_{restaurant_Id}",
                table: "food_Ens",
                column: "{restaurant_Id}",
                principalTable: "restaurant_Ens",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_delivery_Restaurant_Relation_Ens_delivery_Ens_{Delivery_Id}",
                table: "delivery_Restaurant_Relation_Ens");

            migrationBuilder.DropForeignKey(
                name: "FK_delivery_Restaurant_Relation_Ens_restaurant_Ens_{Restaurant_Id}",
                table: "delivery_Restaurant_Relation_Ens");

            migrationBuilder.DropForeignKey(
                name: "FK_food_Ens_restaurant_Ens_{restaurant_Id}",
                table: "food_Ens");

            migrationBuilder.DropForeignKey(
                name: "FK_location_Ens_restaurant_Ens_{Restaurant_En_Id}",
                table: "location_Ens");

            migrationBuilder.DropForeignKey(
                name: "FK_restaurant_Ens_location_Ens_{location_Id}",
                table: "restaurant_Ens");

            migrationBuilder.DropIndex(
                name: "IX_delivery_Restaurant_Relation_Ens_{Delivery_Id}",
                table: "delivery_Restaurant_Relation_Ens");

            migrationBuilder.DropIndex(
                name: "IX_delivery_Restaurant_Relation_Ens_{Restaurant_Id}",
                table: "delivery_Restaurant_Relation_Ens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_restaurant_Ens",
                table: "restaurant_Ens");

            migrationBuilder.DropColumn(
                name: "{Delivery_Id}",
                table: "delivery_Restaurant_Relation_Ens");

            migrationBuilder.DropColumn(
                name: "{Restaurant_Id}",
                table: "delivery_Restaurant_Relation_Ens");

            migrationBuilder.RenameTable(
                name: "restaurant_Ens",
                newName: "Restaurant_En");

            migrationBuilder.RenameIndex(
                name: "IX_restaurant_Ens_{location_Id}",
                table: "Restaurant_En",
                newName: "IX_Restaurant_En_{location_Id}");

            migrationBuilder.AddColumn<int>(
                name: "{Delivery_Id}",
                table: "delivery_Ens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "{Restaurant_Id}",
                table: "Restaurant_En",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurant_En",
                table: "Restaurant_En",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_Ens_{Delivery_Id}",
                table: "delivery_Ens",
                column: "{Delivery_Id}");

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
                name: "FK_food_Ens_Restaurant_En_{restaurant_Id}",
                table: "food_Ens",
                column: "{restaurant_Id}",
                principalTable: "Restaurant_En",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_location_Ens_Restaurant_En_{Restaurant_En_Id}",
                table: "location_Ens",
                column: "{Restaurant_En_Id}",
                principalTable: "Restaurant_En",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_En_delivery_Restaurant_Relation_Ens_{Restaurant_Id}",
                table: "Restaurant_En",
                column: "{Restaurant_Id}",
                principalTable: "delivery_Restaurant_Relation_Ens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_En_location_Ens_{location_Id}",
                table: "Restaurant_En",
                column: "{location_Id}",
                principalTable: "location_Ens",
                principalColumn: "Id");
        }
    }
}
