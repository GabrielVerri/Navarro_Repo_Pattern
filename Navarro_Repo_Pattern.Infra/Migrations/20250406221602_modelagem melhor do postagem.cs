using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Navarro_Repo_Pattern.Infra.Migrations
{
    /// <inheritdoc />
    public partial class modelagemmelhordopostagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Postagens_PostagemId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PostagemId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PostagemId",
                table: "Usuarios");

            migrationBuilder.CreateTable(
                name: "PostagemCurtidas",
                columns: table => new
                {
                    PostagemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostagemCurtidas", x => new { x.PostagemId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_PostagemCurtidas_Postagens_PostagemId",
                        column: x => x.PostagemId,
                        principalTable: "Postagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostagemCurtidas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostagemCurtidas_UsuarioId",
                table: "PostagemCurtidas",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostagemCurtidas");

            migrationBuilder.AddColumn<Guid>(
                name: "PostagemId",
                table: "Usuarios",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PostagemId",
                table: "Usuarios",
                column: "PostagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Postagens_PostagemId",
                table: "Usuarios",
                column: "PostagemId",
                principalTable: "Postagens",
                principalColumn: "Id");
        }
    }
}
