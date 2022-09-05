using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuyensinhVido.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Tuyensinh_Nganh_NganhId",
                table: "tbl_Tuyensinh");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Nganh_TempId",
                table: "Nganh");

            migrationBuilder.RenameTable(
                name: "Nganh",
                newName: "tbl_Nganh");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "tbl_Nganh",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "KhoiThi",
                table: "tbl_Nganh",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KyHieu",
                table: "tbl_Nganh",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "heDaoTaoId",
                table: "tbl_Nganh",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "khoaId",
                table: "tbl_Nganh",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ma",
                table: "tbl_Nganh",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ten",
                table: "tbl_Nganh",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tenTA",
                table: "tbl_Nganh",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Nganh",
                table: "tbl_Nganh",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Tuyensinh_tbl_Nganh_NganhId",
                table: "tbl_Tuyensinh",
                column: "NganhId",
                principalTable: "tbl_Nganh",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Tuyensinh_tbl_Nganh_NganhId",
                table: "tbl_Tuyensinh");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Nganh",
                table: "tbl_Nganh");

            migrationBuilder.DropColumn(
                name: "KhoiThi",
                table: "tbl_Nganh");

            migrationBuilder.DropColumn(
                name: "KyHieu",
                table: "tbl_Nganh");

            migrationBuilder.DropColumn(
                name: "heDaoTaoId",
                table: "tbl_Nganh");

            migrationBuilder.DropColumn(
                name: "khoaId",
                table: "tbl_Nganh");

            migrationBuilder.DropColumn(
                name: "ma",
                table: "tbl_Nganh");

            migrationBuilder.DropColumn(
                name: "ten",
                table: "tbl_Nganh");

            migrationBuilder.DropColumn(
                name: "tenTA",
                table: "tbl_Nganh");

            migrationBuilder.RenameTable(
                name: "tbl_Nganh",
                newName: "Nganh");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Nganh",
                newName: "TempId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Nganh_TempId",
                table: "Nganh",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Tuyensinh_Nganh_NganhId",
                table: "tbl_Tuyensinh",
                column: "NganhId",
                principalTable: "Nganh",
                principalColumn: "TempId");
        }
    }
}
