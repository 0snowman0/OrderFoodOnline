using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    /// <inheritdoc />
    public partial class PhoneUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_delivery_Restaurant_Relation_Ens_delivery_Ens_{Delivery_Id}",
                table: "delivery_Restaurant_Relation_Ens");

            migrationBuilder.DropForeignKey(
                name: "FK_delivery_Restaurant_Relation_Ens_restaurant_Ens_{Restaurant_Id}",
                table: "delivery_Restaurant_Relation_Ens");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "user_Ens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "restaurant_Ens",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OriginalPhotoName",
                table: "food_Ens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "{Restaurant_Id}",
                table: "delivery_Restaurant_Relation_Ens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "{Delivery_Id}",
                table: "delivery_Restaurant_Relation_Ens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsReport",
                table: "commentRestaurant_Ens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReport",
                table: "commentFood_Ens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_delivery_Restaurant_Relation_Ens_delivery_Ens_{Delivery_Id}",
                table: "delivery_Restaurant_Relation_Ens",
                column: "{Delivery_Id}",
                principalTable: "delivery_Ens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_delivery_Restaurant_Relation_Ens_restaurant_Ens_{Restaurant_Id}",
                table: "delivery_Restaurant_Relation_Ens",
                column: "{Restaurant_Id}",
                principalTable: "restaurant_Ens",
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

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "user_Ens");

            migrationBuilder.DropColumn(
                name: "City",
                table: "restaurant_Ens");

            migrationBuilder.DropColumn(
                name: "IsReport",
                table: "commentRestaurant_Ens");

            migrationBuilder.DropColumn(
                name: "IsReport",
                table: "commentFood_Ens");

            migrationBuilder.AlterColumn<string>(
                name: "OriginalPhotoName",
                table: "food_Ens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "{Restaurant_Id}",
                table: "delivery_Restaurant_Relation_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "{Delivery_Id}",
                table: "delivery_Restaurant_Relation_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
        }
    }
}
