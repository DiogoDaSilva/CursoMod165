using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoMod165.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSpecialtyToStaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Specialty",
                table: "Staffs",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "Staffs");
        }
    }
}
