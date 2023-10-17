using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gamezee.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasBenefitCard",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "GameGroups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameGroups_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GameGroupMembers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGroupMembers", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_GameGroupMembers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGroupMembers_GameGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GameGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinPlayers = table.Column<int>(type: "int", nullable: false),
                    MaxPlayers = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Day = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    BenefitCard = table.Column<bool>(type: "bit", nullable: false),
                    Canceled = table.Column<bool>(type: "bit", nullable: false),
                    Public = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountWithBenefitCard = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Address_FieldName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Address_Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address_StreetNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.CheckConstraint("CK_Properties_Duration_GreaterThan", "[Duration] > 0");
                    table.CheckConstraint("CK_Properties_MinPlayers_MaxPlayers", "[MaxPlayers] > [MinPlayers]");
                    table.ForeignKey(
                        name: "FK_Games_GameGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GameGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerFirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PlayerLastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PlayerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HasBenefitCard = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameParticipants_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameParticipants_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGroupMembers_GroupId",
                table: "GameGroupMembers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGroups_CreatorId",
                table: "GameGroups",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_GameParticipants_GameId",
                table: "GameParticipants",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameParticipants_PlayerId",
                table: "GameParticipants",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GroupId",
                table: "Games",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGroupMembers");

            migrationBuilder.DropTable(
                name: "GameParticipants");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GameGroups");

            migrationBuilder.DropColumn(
                name: "HasBenefitCard",
                table: "AspNetUsers");
        }
    }
}
