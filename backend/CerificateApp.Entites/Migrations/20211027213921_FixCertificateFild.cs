using Microsoft.EntityFrameworkCore.Migrations;

namespace CerificateApp.Entites.Migrations
{
    public partial class FixCertificateFild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CetrificateTypeId",
                table: "Certificates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CetrificateTypeId",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
