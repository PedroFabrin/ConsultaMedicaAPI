using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class usuariodto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Medicos_IdMedicoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdMedicoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdMedicoId",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "IdMedico",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MedicoId",
                table: "Usuarios",
                column: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Medicos_MedicoId",
                table: "Usuarios",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Medicos_MedicoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_MedicoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdMedico",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "IdMedicoId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdMedicoId",
                table: "Usuarios",
                column: "IdMedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Medicos_IdMedicoId",
                table: "Usuarios",
                column: "IdMedicoId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
