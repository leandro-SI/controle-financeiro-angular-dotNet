using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Infra.Data.Migrations
{
    public partial class ajustesroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "7ff90334-0050-4432-8623-58b0cf3fb419", "c1302387-880b-4097-a212-f5bf849ab4e9", "Administrador do sistema", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "cb9695b5-e212-498f-a808-f572db43e0fd", "0aa09b26-2efa-45c3-bd1a-34747bfab0a5", "Usuário do sistema", "Usuario", "USUARIO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "7ff90334-0050-4432-8623-58b0cf3fb419");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "cb9695b5-e212-498f-a808-f572db43e0fd");

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "2bb269fc-9272-4595-bf8b-51076289e95b", "f975dce5-5096-4bf6-aeec-38e0c85412c8", "Usuário do sistema", "Usuario", "USUARIO" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "8f3a1b0a-4b3d-4b46-8994-e0eb587f8cad", "7d1cf605-4862-4328-bcfb-a2c70f8c4b6e", "Administrador do sistema", "Administrador", "ADMINISTRADOR" });
        }
    }
}
