using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migracion4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_matricula_Salon_SalonId", table: "matricula");

            migrationBuilder.DropForeignKey(
                name: "FK_matricula_persona_PersonaId",
                table: "matricula"
            );

            migrationBuilder.DropIndex(name: "IX_matricula_PersonaId", table: "matricula");

            migrationBuilder.DropIndex(name: "IX_matricula_SalonId", table: "matricula");

            migrationBuilder.DropColumn(name: "PersonaId", table: "matricula");

            migrationBuilder.DropColumn(name: "SalonId", table: "matricula");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_IdPersonaFk",
                table: "matricula",
                column: "IdPersonaFk"
            );

            migrationBuilder.CreateIndex(
                name: "IX_matricula_IdSalonFk",
                table: "matricula",
                column: "IdSalonFk"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_matricula_Salon_IdSalonFk",
                table: "matricula",
                column: "IdSalonFk",
                principalTable: "Salon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_matricula_persona_IdPersonaFk",
                table: "matricula",
                column: "IdPersonaFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_matricula_Salon_IdSalonFk",
                table: "matricula"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_matricula_persona_IdPersonaFk",
                table: "matricula"
            );

            migrationBuilder.DropIndex(name: "IX_matricula_IdPersonaFk", table: "matricula");

            migrationBuilder.DropIndex(name: "IX_matricula_IdSalonFk", table: "matricula");

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "matricula",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "SalonId",
                table: "matricula",
                type: "int",
                nullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_matricula_PersonaId",
                table: "matricula",
                column: "PersonaId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_matricula_SalonId",
                table: "matricula",
                column: "SalonId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_matricula_Salon_SalonId",
                table: "matricula",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_matricula_persona_PersonaId",
                table: "matricula",
                column: "PersonaId",
                principalTable: "persona",
                principalColumn: "Id"
            );
        }
    }
}
