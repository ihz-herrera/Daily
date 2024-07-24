using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BISoft.Ejercicios.Infraestructura.Migrations
{
    public partial class Outbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    messageType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    payload = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    processedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    retryCount = table.Column<int>(type: "int", nullable: false),
                    failureReason = table.Column<string>(type: "varchar(200)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutboxMessages");

          
        }
    }
}
