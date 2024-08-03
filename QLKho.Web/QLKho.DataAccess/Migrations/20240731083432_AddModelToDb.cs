using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLKho.DataAccess.Migrations
{
    public partial class AddModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SoLo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distribution = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kho",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_kho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hien_thi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    nguoi_tao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime", nullable: false),
                    cap_nhat = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kho", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ncc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_ncc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hien_thi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ten_day_du = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    loai_ncc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    logo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nguoi_dai_dien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sdt = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    tinh_trang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nv_phu_trach = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime", nullable: false),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "san_pham",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_san_pham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    hien_thi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    nhom_san_pham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    hang_sx = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    hinh_anh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dia_chi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    thong_tin = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    han_su_dung = table.Column<DateTime>(type: "datetime", nullable: false),
                    quy_cach = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dvt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gia_nhap = table.Column<double>(type: "float", nullable: false),
                    sl_toi_thieu = table.Column<int>(type: "int", nullable: false),
                    sl_toi_da = table.Column<int>(type: "int", nullable: false),
                    sl_nhap = table.Column<int>(type: "int", nullable: false),
                    sl_xuat = table.Column<int>(type: "int", nullable: false),
                    sl_ton = table.Column<int>(type: "int", nullable: false),
                    trang_thai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime", nullable: false),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime", nullable: false),
                    nguoi_tao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_san_pham", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "thong_tin_cty",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_cty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ten_day_du = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    nguoi_dai_dien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dia_chi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    sdt = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    website = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime", nullable: false),
                    ngay_update = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thong_tin_cty", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "xuat_kho",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loat_xuat = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngay_xuat = table.Column<DateTime>(type: "datetime", nullable: false),
                    nhan_vien_id = table.Column<int>(type: "int", nullable: false),
                    ma_hoa_don = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    sl_san_pham = table.Column<int>(type: "int", nullable: false),
                    sl_xuat = table.Column<int>(type: "int", nullable: false),
                    noi_dung_xuat = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime", nullable: false),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime", nullable: false),
                    nguoi_tao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xuat_kho", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nhap_kho",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loai_nhap = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngay_nhap = table.Column<DateTime>(type: "datetime", nullable: false),
                    ncc_id = table.Column<int>(type: "int", nullable: false),
                    kho_id = table.Column<int>(type: "int", nullable: false),
                    sl_nhap = table.Column<int>(type: "int", nullable: false),
                    nguoi_giao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    noi_dung_nhap = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime", nullable: true),
                    nguoi_tao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhap_kho", x => x.id);
                    table.ForeignKey(
                        name: "FK_nhap_kho_kho_kho_id",
                        column: x => x.kho_id,
                        principalTable: "kho",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nhap_kho_ncc_ncc_id",
                        column: x => x.ncc_id,
                        principalTable: "ncc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "xuat_kho_ct",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiXuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    xuat_kho_id = table.Column<int>(type: "int", nullable: false),
                    ngay_xuat = table.Column<DateTime>(type: "datetime", nullable: false),
                    san_pham_id = table.Column<int>(type: "int", nullable: false),
                    ten_san_pham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    nhom_san_pham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    hang_sx = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    hinh_anh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    thong_tin = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    quy_cach = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dvt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    so_lo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngay_het_han = table.Column<DateTime>(type: "datetime", nullable: false),
                    sl_xuat = table.Column<int>(type: "int", nullable: false),
                    sl_xuat_tong = table.Column<int>(type: "int", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime", nullable: false),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime", nullable: false),
                    nguoi_tao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xuat_kho_ct", x => x.id);
                    table.ForeignKey(
                        name: "FK_xuat_kho_ct_san_pham_san_pham_id",
                        column: x => x.san_pham_id,
                        principalTable: "san_pham",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_xuat_kho_ct_xuat_kho_xuat_kho_id",
                        column: x => x.xuat_kho_id,
                        principalTable: "xuat_kho",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nhap_kho_ct",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nhap_kho_id = table.Column<int>(type: "int", nullable: false),
                    ngay_nhap = table.Column<DateTime>(type: "datetime", nullable: false),
                    san_pham_id = table.Column<int>(type: "int", nullable: false),
                    nhom_san_pham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    hang_sx = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    hinh_anh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    thong_tin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    han_su_dung = table.Column<DateTime>(type: "datetime", nullable: false),
                    quy_cach = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dvt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    so_lo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    gia_nhap = table.Column<double>(type: "float", nullable: false),
                    sl_nhap = table.Column<int>(type: "int", nullable: false),
                    sl_xuat = table.Column<int>(type: "int", nullable: false),
                    sl_ton = table.Column<int>(type: "int", nullable: false),
                    ngay_het_han = table.Column<DateTime>(type: "datetime", nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime", nullable: false),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime", nullable: false),
                    nguoi_tao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhap_kho_ct", x => x.id);
                    table.ForeignKey(
                        name: "FK_nhap_kho_ct_nhap_kho_nhap_kho_id",
                        column: x => x.nhap_kho_id,
                        principalTable: "nhap_kho",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nhap_kho_ct_san_pham_san_pham_id",
                        column: x => x.san_pham_id,
                        principalTable: "san_pham",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nhap_kho_kho_id",
                table: "nhap_kho",
                column: "kho_id");

            migrationBuilder.CreateIndex(
                name: "IX_nhap_kho_ncc_id",
                table: "nhap_kho",
                column: "ncc_id");

            migrationBuilder.CreateIndex(
                name: "IX_nhap_kho_ct_nhap_kho_id",
                table: "nhap_kho_ct",
                column: "nhap_kho_id");

            migrationBuilder.CreateIndex(
                name: "IX_nhap_kho_ct_san_pham_id",
                table: "nhap_kho_ct",
                column: "san_pham_id");

            migrationBuilder.CreateIndex(
                name: "IX_xuat_kho_ct_san_pham_id",
                table: "xuat_kho_ct",
                column: "san_pham_id");

            migrationBuilder.CreateIndex(
                name: "IX_xuat_kho_ct_xuat_kho_id",
                table: "xuat_kho_ct",
                column: "xuat_kho_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "nhap_kho_ct");

            migrationBuilder.DropTable(
                name: "thong_tin_cty");

            migrationBuilder.DropTable(
                name: "xuat_kho_ct");

            migrationBuilder.DropTable(
                name: "nhap_kho");

            migrationBuilder.DropTable(
                name: "san_pham");

            migrationBuilder.DropTable(
                name: "xuat_kho");

            migrationBuilder.DropTable(
                name: "kho");

            migrationBuilder.DropTable(
                name: "ncc");
        }
    }
}
