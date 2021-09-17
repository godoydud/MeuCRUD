using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuCRUD.Migrations
{
    public partial class AgoraVaiqueVai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_UsuarioImagem_ImagemId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ImagemId",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "ImagemId",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ImagemId",
                table: "Usuario",
                column: "ImagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_UsuarioImagem_ImagemId",
                table: "Usuario",
                column: "ImagemId",
                principalTable: "UsuarioImagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_UsuarioImagem_ImagemId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ImagemId",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "ImagemId",
                table: "Usuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ImagemId",
                table: "Usuario",
                column: "ImagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_UsuarioImagem_ImagemId",
                table: "Usuario",
                column: "ImagemId",
                principalTable: "UsuarioImagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
