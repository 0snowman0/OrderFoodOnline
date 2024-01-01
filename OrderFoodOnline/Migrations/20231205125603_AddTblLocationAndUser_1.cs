using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    /// <inheritdoc />
    public partial class AddTblLocationAndUser_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_location_Ens_{Food_En_Id}",
                table: "location_Ens");

            migrationBuilder.DropColumn(
                name: "address",
                table: "food_Ens");

            migrationBuilder.CreateTable(
                name: "user_Ens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Ens", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_location_Ens_{Food_En_Id}",
                table: "location_Ens",
                column: "{Food_En_Id}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_Ens");

            migrationBuilder.DropIndex(
                name: "IX_location_Ens_{Food_En_Id}",
                table: "location_Ens");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "food_Ens",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_location_Ens_{Food_En_Id}",
                table: "location_Ens",
                column: "{Food_En_Id}",
                unique: true,
                filter: "[{Food_En_Id}] IS NOT NULL");
        }
    }
}
