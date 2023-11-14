﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DragaliaAPI.Database.Migrations
{
    /// <inheritdoc />
    public partial class wall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerQuestWalls",
                columns: table => new
                {
                    DeviceAccountId = table.Column<string>(type: "text", nullable: false),
                    WallId = table.Column<int>(type: "integer", nullable: false),
                    WallLevel = table.Column<int>(type: "integer", nullable: false),
                    IsStartNextLevel = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerQuestWalls", x => new { x.DeviceAccountId, x.WallId });
                    table.ForeignKey(
                        name: "FK_PlayerQuestWalls_Players_DeviceAccountId",
                        column: x => x.DeviceAccountId,
                        principalTable: "Players",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerQuestWalls_DeviceAccountId",
                table: "PlayerQuestWalls",
                column: "DeviceAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerQuestWalls");
        }
    }
}
