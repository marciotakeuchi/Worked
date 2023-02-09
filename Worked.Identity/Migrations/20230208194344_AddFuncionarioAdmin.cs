using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Worked.Infra.Migrations
{
    public partial class AddFuncionarioAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_RegimeTrabalhistaId",
                table: "Funcionario");

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "Id", "CargoId", "Cpf", "DataNascimento", "Email", "GestorId", "Nome", "RegimeTrabalhistaId", "Telefone" },
                values: new object[] { 1, 3, "00000000000", new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), "admin@admin.com", null, "Admin do Sistema", 3, "11 1111-1111" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bafd5fe2-b9e2-461d-3254-08db06712de6"),
                column: "FuncionarioId",
                value: 1);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_RegimeTrabalhistaId",
                table: "Funcionario");

            migrationBuilder.DeleteData(
                table: "Funcionario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bafd5fe2-b9e2-461d-3254-08db06712de6"),
                column: "FuncionarioId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_RegimeTrabalhistaId",
                table: "Funcionario",
                column: "RegimeTrabalhistaId");
        }
    }
}
