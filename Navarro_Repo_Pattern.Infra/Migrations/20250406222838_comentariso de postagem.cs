using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Navarro_Repo_Pattern.Infra.Migrations
{
    /// <inheritdoc />
    public partial class comentarisodepostagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postagens_Postagens_PostagemId",
                table: "Postagens");

            migrationBuilder.DropIndex(
                name: "IX_Postagens_PostagemId",
                table: "Postagens");

            migrationBuilder.DropColumn(
                name: "PostagemId",
                table: "Postagens");

            migrationBuilder.CreateTable(
                name: "PostagemPostagem",
                columns: table => new
                {
                    ComentariosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostagemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostagemPostagem", x => new { x.ComentariosId, x.PostagemId });
                    table.ForeignKey(
                        name: "FK_PostagemPostagem_Postagens_ComentariosId",
                        column: x => x.ComentariosId,
                        principalTable: "Postagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostagemPostagem_Postagens_PostagemId",
                        column: x => x.PostagemId,
                        principalTable: "Postagens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostagemPostagem_PostagemId",
                table: "PostagemPostagem",
                column: "PostagemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostagemPostagem");

            migrationBuilder.AddColumn<Guid>(
                name: "PostagemId",
                table: "Postagens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Postagens_PostagemId",
                table: "Postagens",
                column: "PostagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Postagens_Postagens_PostagemId",
                table: "Postagens",
                column: "PostagemId",
                principalTable: "Postagens",
                principalColumn: "Id");
        }
    }
}
