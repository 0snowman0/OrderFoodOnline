using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    /// <inheritdoc />
    public partial class ManyChange_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accuracy",
                table: "location_Ens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Accuracy",
                table: "location_Ens",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
