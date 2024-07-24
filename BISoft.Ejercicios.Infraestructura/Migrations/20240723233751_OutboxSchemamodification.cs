using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BISoft.Ejercicios.Infraestructura.Migrations
{
    public partial class OutboxSchemamodification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "OutboxMessages",
                newName: "OutboxMessages",
                newSchema: "outbox");

            migrationBuilder.RenameTable(
                name: "genProductosCat",
                schema: "outbox",
                newName: "genProductosCat",
                newSchema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "OutboxMessages",
                schema: "outbox",
                newName: "OutboxMessages");

            migrationBuilder.RenameTable(
                name: "genProductosCat",
                schema: "dbo",
                newName: "genProductosCat",
                newSchema: "outbox");
        }
    }
}
