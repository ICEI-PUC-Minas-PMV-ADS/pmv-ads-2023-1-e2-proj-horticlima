using Microsoft.EntityFrameworkCore.Migrations;

namespace Horticlima.Migrations
{
    public partial class UpdateCarrinho1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItem_Produtos_ProdutoId",
                table: "CarrinhoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoItem",
                table: "CarrinhoItem");

            migrationBuilder.RenameTable(
                name: "CarrinhoItem",
                newName: "CarrinhoItens");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoItem_ProdutoId",
                table: "CarrinhoItens",
                newName: "IX_CarrinhoItens_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoItens",
                table: "CarrinhoItens",
                column: "CarrinhoItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItens_Produtos_ProdutoId",
                table: "CarrinhoItens",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItens_Produtos_ProdutoId",
                table: "CarrinhoItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoItens",
                table: "CarrinhoItens");

            migrationBuilder.RenameTable(
                name: "CarrinhoItens",
                newName: "CarrinhoItem");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoItens_ProdutoId",
                table: "CarrinhoItem",
                newName: "IX_CarrinhoItem_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoItem",
                table: "CarrinhoItem",
                column: "CarrinhoItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItem_Produtos_ProdutoId",
                table: "CarrinhoItem",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
