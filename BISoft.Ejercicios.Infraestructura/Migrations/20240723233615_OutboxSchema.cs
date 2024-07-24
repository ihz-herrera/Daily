using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BISoft.Ejercicios.Infraestructura.Migrations
{
    public partial class OutboxSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "outbox");

            migrationBuilder.RenameTable(
                name: "genProductosCat",
                newName: "genProductosCat",
                newSchema: "outbox");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "genProductosCat",
                schema: "outbox",
                newName: "genProductosCat");
        }
    }
}
