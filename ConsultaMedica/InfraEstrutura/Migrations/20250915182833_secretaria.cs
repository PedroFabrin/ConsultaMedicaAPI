using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class secretaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_medicoId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Usuarios_usuarioId",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_medicoId",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_usuarioId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "medicoId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Consultas");

            migrationBuilder.AddColumn<int>(
                name: "IdMedico",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Secretarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretarias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdMedico",
                table: "Consultas",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdUsuario",
                table: "Consultas",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_IdMedico",
                table: "Consultas",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Usuarios_IdUsuario",
                table: "Consultas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_IdMedico",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Usuarios_IdUsuario",
                table: "Consultas");

            migrationBuilder.DropTable(
                name: "Secretarias");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_IdMedico",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_IdUsuario",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "IdMedico",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Consultas");

            migrationBuilder.AddColumn<int>(
                name: "medicoId",
                table: "Consultas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Consultas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_medicoId",
                table: "Consultas",
                column: "medicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_usuarioId",
                table: "Consultas",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_medicoId",
                table: "Consultas",
                column: "medicoId",
                principalTable: "Medicos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Usuarios_usuarioId",
                table: "Consultas",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
