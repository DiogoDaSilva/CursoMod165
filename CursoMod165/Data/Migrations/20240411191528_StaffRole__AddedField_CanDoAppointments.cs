using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoMod165.Data.Migrations
{
    /// <inheritdoc />
    public partial class StaffRole__AddedField_CanDoAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanDoAppointments",
                table: "StaffRoles",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanDoAppointments",
                table: "StaffRoles");
        }
    }
}
