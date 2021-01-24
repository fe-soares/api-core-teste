using Microsoft.EntityFrameworkCore.Migrations;

namespace De.Data.Migrations
{
    public partial class tste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoFornecedor",
                table: "Fornecedores",
                type: "Integer(1)",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoFornecedor",
                table: "Fornecedores");
        }
    }
}
