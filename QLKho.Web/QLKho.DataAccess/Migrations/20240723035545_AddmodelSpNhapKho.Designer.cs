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
    [Migration("20240723035545_AddmodelSpNhapKho")]
    partial class AddmodelSpNhapKho
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QLKho.Models.CongTy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TenCTy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CongTies");
                });

            modelBuilder.Entity("QLKho.Models.Kho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TenKho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenViTri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Khos");
                });

            modelBuilder.Entity("QLKho.Models.NhaCungCap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TenNhaCungCap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NhaCungCaps");
                });

            modelBuilder.Entity("QLKho.Models.NhapKho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("KhoId")
                        .HasColumnType("int");

                    b.Property<string>("LoaiNhap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiTao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nguoigiao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NhaCungCapId")
                        .HasColumnType("int");

                    b.Property<string>("NoiDungNhap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuongNhap")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KhoId");

                    b.HasIndex("NhaCungCapId");

                    b.ToTable("NhapKhos");
                });

            modelBuilder.Entity("QLKho.Models.NhapKhoCT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Dvt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ghichu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GiaNhap")
                        .HasColumnType("float");

                    b.Property<DateTime>("HanSuDung")
                        .HasColumnType("datetime2");

                    b.Property<string>("HangXanXuat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayHetHan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiTao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NhapKhoId")
                        .HasColumnType("int");

                    b.Property<string>("NhomSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuyCach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SLNhap")
                        .HasColumnType("int");

                    b.Property<int>("SLTon")
                        .HasColumnType("int");

                    b.Property<int>("SLXuat")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<string>("Solo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThongTin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NhapKhoId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("NhapKhoCTs");
                });

            modelBuilder.Entity("QLKho.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dvt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ghichu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GiaNhap")
                        .HasColumnType("float");

                    b.Property<DateTime>("HanSuDung")
                        .HasColumnType("datetime2");

                    b.Property<string>("HangSanXuat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HienThi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiTao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NhomSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuyCach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SLNhap")
                        .HasColumnType("int");

                    b.Property<int>("SLToiDa")
                        .HasColumnType("int");

                    b.Property<int>("SLToiThieu")
                        .HasColumnType("int");

                    b.Property<int>("SLTon")
                        .HasColumnType("int");

                    b.Property<int>("SLXuat")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThongTin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SanPhams");
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
#pragma warning restore 612, 618
        }
    }
}