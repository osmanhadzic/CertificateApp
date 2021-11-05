using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CerificateApp.Entites.Migrations
{
    public partial class FixEntityRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Supplier_SupplierId1",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_UploadFile_UploadFileId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_User_UserId",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_SupplierId1",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_UploadFileId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "SupplierId1",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "UploadFileId",
                table: "Certificates");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Supplier",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Certificates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Certificates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UploadFileDocumentId",
                table: "Certificates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_SupplierId",
                table: "Certificates",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_UploadFileDocumentId",
                table: "Certificates",
                column: "UploadFileDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Supplier_SupplierId",
                table: "Certificates",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_UploadFile_UploadFileDocumentId",
                table: "Certificates",
                column: "UploadFileDocumentId",
                principalTable: "UploadFile",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_User_UserId",
                table: "Certificates",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Supplier_SupplierId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_UploadFile_UploadFileDocumentId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_User_UserId",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_SupplierId",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_UploadFileDocumentId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "UploadFileDocumentId",
                table: "Certificates");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Supplier",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId1",
                table: "Certificates",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "UploadFileId",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_SupplierId1",
                table: "Certificates",
                column: "SupplierId1");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_UploadFileId",
                table: "Certificates",
                column: "UploadFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Supplier_SupplierId1",
                table: "Certificates",
                column: "SupplierId1",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_UploadFile_UploadFileId",
                table: "Certificates",
                column: "UploadFileId",
                principalTable: "UploadFile",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_User_UserId",
                table: "Certificates",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
