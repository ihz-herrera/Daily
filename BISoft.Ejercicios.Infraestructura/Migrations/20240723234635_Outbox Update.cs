using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BISoft.Ejercicios.Infraestructura.Migrations
{
    public partial class OutboxUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventType",
                schema: "outbox",
                table: "OutboxMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventType",
                schema: "outbox",
                table: "OutboxMessages");
        }
    }
}
