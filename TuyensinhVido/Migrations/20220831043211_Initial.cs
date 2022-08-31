using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuyensinhVido.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Nganh",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    ma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhoiThi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    khoaId = table.Column<int>(type: "int", nullable: true),
                    heDaoTaoId = table.Column<int>(type: "int", nullable: true),
                    tenTA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KyHieu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Nganh", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Tuyensinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hoten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CMND = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hocba = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NganhId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Tuyensinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Tuyensinh_tbl_Nganh_NganhId",
                        column: x => x.NganhId,
                        principalTable: "tbl_Nganh",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Tuyensinh_NganhId",
                table: "tbl_Tuyensinh",
                column: "NganhId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Tuyensinh");

            migrationBuilder.DropTable(
                name: "tbl_Nganh");
        }
    }
}
