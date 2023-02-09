using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Worked.Infra.Migrations
{
    public partial class remocaoIndicesExclusivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_RegimeTrabalhistaId",
                table: "Funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_RegimeTrabalhistaId",
                table: "Funcionario",
                column: "RegimeTrabalhistaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_RegimeTrabalhistaId",
                table: "Funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario",
                column: "CargoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_RegimeTrabalhistaId",
                table: "Funcionario",
                column: "RegimeTrabalhistaId",
                unique: true);
        }
    }
}
