using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejercicio.Infraestructura.Datos.Migrations
{
    public partial class CreacionBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    CodigoArticulo = table.Column<string>(nullable: false),
                    NombreArticulo = table.Column<string>(nullable: false),
                    PrecioArticulo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockArticulo = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.CodigoArticulo);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreCliente = table.Column<string>(nullable: false),
                    ApellidoCliente = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    IdOrden = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaOrden = table.Column<DateTime>(nullable: false),
                    IdCliente = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.IdOrden);
                    table.ForeignKey(
                        name: "FK_Orden_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenArticulo",
                columns: table => new
                {
                    CodigoArticulo = table.Column<string>(nullable: false),
                    IdOrden = table.Column<long>(nullable: false),
                    CantidadArticulo = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenArticulo", x => new { x.CodigoArticulo, x.IdOrden });
                    table.ForeignKey(
                        name: "FK_OrdenArticulo_Articulo_CodigoArticulo",
                        column: x => x.CodigoArticulo,
                        principalTable: "Articulo",
                        principalColumn: "CodigoArticulo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenArticulo_Orden_IdOrden",
                        column: x => x.IdOrden,
                        principalTable: "Orden",
                        principalColumn: "IdOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdCliente",
                table: "Orden",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenArticulo_IdOrden",
                table: "OrdenArticulo",
                column: "IdOrden");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenArticulo");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
