using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BISoft.Ejercicios.Infraestructura.Migrations
{
    public partial class Agregar_Referencias_Producto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                schema: "dbo",
                table: "genProductosCat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FabricanteId",
                schema: "dbo",
                table: "genProductosCat",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaId",
                schema: "dbo",
                table: "genProductosCat");

            migrationBuilder.DropColumn(
                name: "FabricanteId",
                schema: "dbo",
                table: "genProductosCat");
        }
    }
}
