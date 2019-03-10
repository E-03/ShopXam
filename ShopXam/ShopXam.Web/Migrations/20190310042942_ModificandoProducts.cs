using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopXam.Web.Migrations
{
    public partial class ModificandoProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaCompra",
                table: "Prooducto",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Prooducto",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaVenta",
                table: "Prooducto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltimaVenta",
                table: "Prooducto");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaCompra",
                table: "Prooducto",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Prooducto",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
