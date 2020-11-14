using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaApi.Migrations
{
    public partial class Version20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Consultas_ConsultaCodigo",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "ConsultaCodigo",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Clientes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Consultas_ConsultaCodigo",
                table: "Clientes",
                column: "ConsultaCodigo",
                principalTable: "Consultas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Consultas_ConsultaCodigo",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "ConsultaCodigo",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Consultas_ConsultaCodigo",
                table: "Clientes",
                column: "ConsultaCodigo",
                principalTable: "Consultas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
