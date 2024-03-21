using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoMod165.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateStaffRole_AddedRelationToStaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffRoleID",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StaffRoles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRoles", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StaffRoleID",
                table: "Staffs",
                column: "StaffRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_StaffRoles_StaffRoleID",
                table: "Staffs",
                column: "StaffRoleID",
                principalTable: "StaffRoles",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_StaffRoles_StaffRoleID",
                table: "Staffs");

            migrationBuilder.DropTable(
                name: "StaffRoles");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_StaffRoleID",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "StaffRoleID",
                table: "Staffs");
        }
    }
}
