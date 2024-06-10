using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig10_Message_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "messageRelations",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    RecevierId = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messageRelations", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_messageRelations_Writers_RecevierId",
                        column: x => x.RecevierId,
                        principalTable: "Writers",
                        principalColumn: "WriterId");
                    table.ForeignKey(
                        name: "FK_messageRelations_Writers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Writers",
                        principalColumn: "WriterId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_messageRelations_RecevierId",
                table: "messageRelations",
                column: "RecevierId");

            migrationBuilder.CreateIndex(
                name: "IX_messageRelations_SenderId",
                table: "messageRelations",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messageRelations");
        }
    }
}
