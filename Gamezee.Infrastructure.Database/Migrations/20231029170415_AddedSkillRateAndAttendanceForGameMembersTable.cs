using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gamezee.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedSkillRateAndAttendanceForGameMembersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameAttendance",
                table: "GameGroupMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillRate",
                table: "GameGroupMembers",
                type: "int",
                nullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Properties_SkillRate_MaxValue",
                table: "GameGroupMembers",
                sql: "[SkillRate] <= 5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Properties_SkillRate_MaxValue",
                table: "GameGroupMembers");

            migrationBuilder.DropColumn(
                name: "GameAttendance",
                table: "GameGroupMembers");

            migrationBuilder.DropColumn(
                name: "SkillRate",
                table: "GameGroupMembers");
        }
    }
}
