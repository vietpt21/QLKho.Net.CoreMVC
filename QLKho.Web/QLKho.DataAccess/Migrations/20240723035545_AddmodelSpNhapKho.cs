using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLKho.DataAccess.Migrations
{
    public partial class AddmodelSpNhapKho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HienThi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhomSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HangSanXuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThongTin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HanSuDung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuyCach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dvt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaNhap = table.Column<double>(type: "float", nullable: false),
                    SLToiThieu = table.Column<int>(type: "int", nullable: false),
                    SLToiDa = table.Column<int>(type: "int", nullable: false),
                    SLNhap = table.Column<int>(type: "int", nullable: false),
                    SLXuat = table.Column<int>(type: "int", nullable: false),
                    SLTon = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhapKhoCTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhapKhoId = table.Column<int>(type: "int", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    NhomSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HangXanXuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThongTin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HanSuDung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuyCach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dvt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Solo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaNhap = table.Column<double>(type: "float", nullable: false),
                    SLNhap = table.Column<int>(type: "int", nullable: false),
                    SLXuat = table.Column<int>(type: "int", nullable: false),
                    SLTon = table.Column<int>(type: "int", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhapKhoCTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhapKhoCTs_NhapKhos_NhapKhoId",
                        column: x => x.NhapKhoId,
                        principalTable: "NhapKhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhapKhoCTs_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhoCTs_NhapKhoId",
                table: "NhapKhoCTs",
                column: "NhapKhoId");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhoCTs_SanPhamId",
                table: "NhapKhoCTs",
                column: "SanPhamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhapKhoCTs");

            migrationBuilder.DropTable(
                name: "SanPhams");
        }
    }
}
