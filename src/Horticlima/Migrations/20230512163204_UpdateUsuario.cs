using Microsoft.EntityFrameworkCore.Migrations;

namespace Horticlima.Migrations
{
    public partial class UpdateUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "Usuarios",
                newName: "Documento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "Usuarios",
                newName: "CNPJ");
        }
    }
}
