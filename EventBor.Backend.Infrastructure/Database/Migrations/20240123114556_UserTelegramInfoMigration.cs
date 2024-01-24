using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventBor.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserTelegramInfoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTelegramInfos",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TelegramId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTelegramInfos", x => new { x.UserId, x.TelegramId });
                    table.ForeignKey(
                        name: "FK_UserTelegramInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTelegramInfos_UserId",
                table: "UserTelegramInfos",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTelegramInfos");
        }
    }
}
