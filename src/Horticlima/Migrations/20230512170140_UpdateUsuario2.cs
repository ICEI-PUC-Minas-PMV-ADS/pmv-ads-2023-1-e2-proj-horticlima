using Microsoft.EntityFrameworkCore.Migrations;

namespace Horticlima.Migrations
{
    public partial class UpdateUsuario2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "Usuarios",
                newName: "CPF");

            migrationBuilder.AddColumn<int>(
                name: "CNPJ",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Usuarios",
                newName: "Documento");
        }
    }
}
