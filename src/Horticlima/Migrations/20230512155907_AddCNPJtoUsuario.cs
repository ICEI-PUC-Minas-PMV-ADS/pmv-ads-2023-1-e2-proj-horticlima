using Microsoft.EntityFrameworkCore.Migrations;

namespace Horticlima.Migrations
{
    public partial class AddCNPJtoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_Usuarios_UsarioId",
                table: "Carrinho");

            migrationBuilder.DropIndex(
                name: "IX_Carrinho_UsarioId",
                table: "Carrinho");

            migrationBuilder.DropColumn(
                name: "UsarioId",
                table: "Carrinho");

            migrationBuilder.AddColumn<int>(
                name: "CNPJ",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Preco",
                table: "Produtos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Preco",
                table: "Carrinho",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_UsuarioId",
                table: "Carrinho",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_Usuarios_UsuarioId",
                table: "Carrinho",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_Usuarios_UsuarioId",
                table: "Carrinho");

            migrationBuilder.DropIndex(
                name: "IX_Carrinho_UsuarioId",
                table: "Carrinho");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Usuarios");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produtos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Carrinho",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UsarioId",
                table: "Carrinho",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_UsarioId",
                table: "Carrinho",
                column: "UsarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_Usuarios_UsarioId",
                table: "Carrinho",
                column: "UsarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
