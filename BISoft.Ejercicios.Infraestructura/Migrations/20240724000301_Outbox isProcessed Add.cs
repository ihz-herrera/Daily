using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BISoft.Ejercicios.Infraestructura.Migrations
{
    public partial class OutboxisProcessedAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                schema: "outbox",
                table: "OutboxMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProcessed",
                schema: "outbox",
                table: "OutboxMessages");
        }
    }
}
