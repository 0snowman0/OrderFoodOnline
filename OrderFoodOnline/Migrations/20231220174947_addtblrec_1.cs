using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    /// <inheritdoc />
    public partial class addtblrec_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "recruitment_Ens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    restaurant_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    salary = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    file_Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Restaurant_EnId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recruitment_Ens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recruitment_Ens_restaurant_Ens_Restaurant_EnId",
                        column: x => x.Restaurant_EnId,
                        principalTable: "restaurant_Ens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_recruitment_Ens_Restaurant_EnId",
                table: "recruitment_Ens",
                column: "Restaurant_EnId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recruitment_Ens");
        }
    }
}
