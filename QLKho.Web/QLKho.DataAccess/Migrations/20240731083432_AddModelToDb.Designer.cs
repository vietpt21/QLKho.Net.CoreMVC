﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLKho.DataAccess.Data;

#nullable disable

namespace QLKho.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240731083432_AddModelToDb")]
    partial class AddModelToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QLKho.Models.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Distribution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SoLo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("QLKho.Models.CongTy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("dia_chi");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_update");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_tao");

                    b.Property<string>("NguoiDaiDien")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nguoi_dai_dien");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("sdt");

                    b.Property<string>("TenCTy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ten_cty");

                    b.Property<string>("TenDayDu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ten_day_du");

                    b.Property<string>("Wensite")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("website");

                    b.HasKey("Id");

                    b.ToTable("thong_tin_cty", (string)null);
                });

            modelBuilder.Entity("QLKho.Models.Kho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("ghi_chu");

                    b.Property<string>("HienThi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("hien_thi");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime")
                        .HasColumnName("cap_nhat");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_tao");

                    b.Property<string>("NguoiTao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nguoi_tao");

                    b.Property<string>("TenKho")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ten_kho");

                    b.HasKey("Id");

                    b.ToTable("kho", (string)null);
                });

            modelBuilder.Entity("QLKho.Models.NhaCungCap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ghi_chu");

                    b.Property<string>("HienThi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("hien_thi");

                    b.Property<string>("LoaiNCC")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("loai_ncc");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("logo");

                    b.Property<string>("NVPhuTrach")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nv_phu_trach");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_tao");

                    b.Property<string>("NguoiDaiDien")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nguoi_dai_dien");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sdt");

                    b.Property<string>("TenDayDu")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("ten_day_du");

                    b.Property<string>("TenNhaCungCap")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ten_ncc");

                    b.Property<string>("TinhTrang")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("tinh_trang");

                    b.HasKey("Id");

                    b.ToTable("ncc", (string)null);
                });

            modelBuilder.Entity("QLKho.Models.NhapKho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("KhoId")
                        .HasColumnType("int")
                        .HasColumnName("kho_id");

                    b.Property<string>("LoaiNhap")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("loai_nhap");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_nhap");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_tao");

                    b.Property<string>("NguoiTao")
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("nguoi_tao");

                    b.Property<string>("Nguoigiao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("nguoi_giao");

                    b.Property<int>("NhaCungCapId")
                        .HasColumnType("int")
                        .HasColumnName("ncc_id");

                    b.Property<string>("NoiDungNhap")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("noi_dung_nhap");

                    b.Property<int>("SoLuongNhap")
                        .HasColumnType("int")
                        .HasColumnName("sl_nhap");

                    b.HasKey("Id");

                    b.HasIndex("KhoId");

                    b.HasIndex("NhaCungCapId");

                    b.ToTable("nhap_kho", (string)null);
                });

            modelBuilder.Entity("QLKho.Models.NhapKhoCT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Dvt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("dvt");

                    b.Property<string>("Ghichu")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("ghi_chu");

                    b.Property<double>("GiaNhap")
                        .HasColumnType("float")
                        .HasColumnName("gia_nhap");

                    b.Property<DateTime>("HanSuDung")
                        .HasColumnType("datetime")
                        .HasColumnName("han_su_dung");

                    b.Property<string>("HangXanXuat")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("hang_sx");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("hinh_anh");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<DateTime>("NgayHetHan")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_het_han");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_nhap");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_tao");

                    b.Property<string>("NguoiTao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("nguoi_tao");

                    b.Property<int>("NhapKhoId")
                        .HasColumnType("int")
                        .HasColumnName("nhap_kho_id");

                    b.Property<string>("NhomSanPham")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("nhom_san_pham");

                    b.Property<string>("QuyCach")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("quy_cach");

                    b.Property<int>("SLNhap")
                        .HasColumnType("int")
                        .HasColumnName("sl_nhap");

                    b.Property<int>("SLTon")
                        .HasColumnType("int")
                        .HasColumnName("sl_ton");

                    b.Property<int>("SLXuat")
                        .HasColumnType("int")
                        .HasColumnName("sl_xuat");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int")
                        .HasColumnName("san_pham_id");

                    b.Property<string>("Solo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("so_lo");

                    b.Property<string>("ThongTin")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("thong_tin");

                    b.HasKey("Id");

                    b.HasIndex("NhapKhoId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("nhap_kho_ct", (string)null);
                });

            modelBuilder.Entity("QLKho.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("dia_chi");

                    b.Property<string>("Dvt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("dvt");

                    b.Property<string>("Ghichu")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("ghi_chu");

                    b.Property<double>("GiaNhap")
                        .HasColumnType("float")
                        .HasColumnName("gia_nhap");

                    b.Property<DateTime>("HanSuDung")
                        .HasColumnType("datetime")
                        .HasColumnName("han_su_dung");

                    b.Property<string>("HangSanXuat")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("hang_sx");

                    b.Property<string>("HienThi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("hien_thi");

                    b.Property<string>("HinhAnh")
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("hinh_anh");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_tao");

                    b.Property<string>("NguoiTao")
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("nguoi_tao");

                    b.Property<string>("NhomSanPham")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("nhom_san_pham");

                    b.Property<string>("QuyCach")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("quy_cach");

                    b.Property<int>("SLNhap")
                        .HasColumnType("int")
                        .HasColumnName("sl_nhap");

                    b.Property<int>("SLToiDa")
                        .HasColumnType("int")
                        .HasColumnName("sl_toi_da");

                    b.Property<int>("SLToiThieu")
                        .HasColumnType("int")
                        .HasColumnName("sl_toi_thieu");

                    b.Property<int>("SLTon")
                        .HasColumnType("int")
                        .HasColumnName("sl_ton");

                    b.Property<int>("SLXuat")
                        .HasColumnType("int")
                        .HasColumnName("sl_xuat");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("ten_san_pham");

                    b.Property<string>("ThongTin")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("thong_tin");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("trang_thai");

                    b.HasKey("Id");

                    b.ToTable("san_pham", (string)null);
                });

            modelBuilder.Entity("QLKho.Models.XuatKho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("ghi_chu");

                    b.Property<string>("LoaiXuat")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("loat_xuat");

                    b.Property<string>("MaHoaDon")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("ma_hoa_don");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime>("NgayXuat")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_xuat");

                    b.Property<string>("NguoiTao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("nguoi_tao");

                    b.Property<int>("NhanVienId")
                        .HasColumnType("int")
                        .HasColumnName("nhan_vien_id");

                    b.Property<string>("NoiDungXuat")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("noi_dung_xuat");

                    b.Property<int>("SlSanPham")
                        .HasColumnType("int")
                        .HasColumnName("sl_san_pham");

                    b.Property<int>("SlXuat")
                        .HasColumnType("int")
                        .HasColumnName("sl_xuat");

                    b.HasKey("Id");

                    b.ToTable("xuat_kho", (string)null);
                });

            modelBuilder.Entity("QLKho.Models.XuatKhoCT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Dvt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("dvt");

                    b.Property<string>("HangSanXuat")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("hang_sx");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("hinh_anh");

                    b.Property<string>("LoaiXuat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<DateTime>("NgayHetHan")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_het_han");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime>("NgayXuat")
                        .HasColumnType("datetime")
                        .HasColumnName("ngay_xuat");

                    b.Property<string>("NguoiTao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("nguoi_tao");

                    b.Property<string>("NhomSanPham")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("nhom_san_pham");

                    b.Property<string>("QuyCach")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("quy_cach");

                    b.Property<int>("SLXuat")
                        .HasColumnType("int")
                        .HasColumnName("sl_xuat");

                    b.Property<int>("SLXuatTong")
                        .HasColumnType("int")
                        .HasColumnName("sl_xuat_tong");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int")
                        .HasColumnName("san_pham_id");

                    b.Property<string>("SoLo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("so_lo");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("ten_san_pham");

                    b.Property<string>("ThongTin")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("thong_tin");

                    b.Property<int>("XuatKhoId")
                        .HasColumnType("int")
                        .HasColumnName("xuat_kho_id");

                    b.HasKey("Id");

                    b.HasIndex("SanPhamId");

                    b.HasIndex("XuatKhoId");

                    b.ToTable("xuat_kho_ct", (string)null);
                });

            modelBuilder.Entity("QLKho.Models.NhapKho", b =>
                {
                    b.HasOne("QLKho.Models.Kho", "Kho")
                        .WithMany()
                        .HasForeignKey("KhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLKho.Models.NhaCungCap", "NhaCungCap")
                        .WithMany()
                        .HasForeignKey("NhaCungCapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kho");

                    b.Navigation("NhaCungCap");
                });

            modelBuilder.Entity("QLKho.Models.NhapKhoCT", b =>
                {
                    b.HasOne("QLKho.Models.NhapKho", "NhapKho")
                        .WithMany()
                        .HasForeignKey("NhapKhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLKho.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhapKho");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("QLKho.Models.XuatKhoCT", b =>
                {
                    b.HasOne("QLKho.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLKho.Models.XuatKho", "XuatKho")
                        .WithMany()
                        .HasForeignKey("XuatKhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");

                    b.Navigation("XuatKho");
                });
#pragma warning restore 612, 618
        }
    }
}
