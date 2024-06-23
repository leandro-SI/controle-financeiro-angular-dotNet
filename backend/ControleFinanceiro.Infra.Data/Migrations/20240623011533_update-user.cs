using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Infra.Data.Migrations
{
    public partial class updateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "6a20a075-ad77-408d-85e7-370ae57a2701");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "c7bdf733-99a9-4cd6-80c2-d77e43d9d2ab");

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "2bb269fc-9272-4595-bf8b-51076289e95b", "f975dce5-5096-4bf6-aeec-38e0c85412c8", "Usuário do sistema", "Usuario", "USUARIO" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "8f3a1b0a-4b3d-4b46-8994-e0eb587f8cad", "7d1cf605-4862-4328-bcfb-a2c70f8c4b6e", "Administrador do sistema", "Administrador", "ADMINISTRADOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "2bb269fc-9272-4595-bf8b-51076289e95b");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "8f3a1b0a-4b3d-4b46-8994-e0eb587f8cad");

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "6a20a075-ad77-408d-85e7-370ae57a2701", "12201c11-5af2-40ad-83bc-548a8e16d6a6", "Usuário do sistema", "Usuario", "USUARIO" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "c7bdf733-99a9-4cd6-80c2-d77e43d9d2ab", "c6da3d6a-c188-4106-abf5-b9d4b75def26", "Administrador do sistema", "Administrador", "ADMINISTRADOR" });
        }
    }
}
