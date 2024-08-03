using Microsoft.EntityFrameworkCore;
using QLKho.Models;
using System;

namespace QLKho.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Kho> Khos { get; set; }
        public DbSet<CongTy> CongTies { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<NhapKho> NhapKhos { get; set; }
        public DbSet<NhapKhoCT> NhapKhoCTs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<XuatKho> XuatKhos { get; set; }
        public DbSet<XuatKhoCT> XuatKhoCTs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define table names
            modelBuilder.Entity<CongTy>().ToTable("thong_tin_cty");
            modelBuilder.Entity<Kho>().ToTable("kho");
            modelBuilder.Entity<NhaCungCap>().ToTable("ncc");
            modelBuilder.Entity<SanPham>().ToTable("san_pham");
            modelBuilder.Entity<NhapKho>().ToTable("nhap_kho");
            modelBuilder.Entity<NhapKhoCT>().ToTable("nhap_kho_ct");
            modelBuilder.Entity<XuatKho>().ToTable("xuat_kho");
            modelBuilder.Entity<XuatKhoCT>().ToTable("xuat_kho_ct");

            // Define column configurations
            modelBuilder.Entity<CongTy>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();  // Ensure Id is auto-incremented
                entity.Property(e => e.TenCTy).HasColumnName("ten_cty").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.TenDayDu).HasColumnName("ten_day_du").HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.NguoiDaiDien).HasColumnName("nguoi_dai_dien").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.DiaChi).HasColumnName("dia_chi").HasMaxLength(250).IsUnicode();
                entity.Property(e => e.SDT).HasColumnName("sdt").HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Wensite).HasColumnName("website").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.NgayTao).HasColumnName("ngay_tao").HasColumnType("datetime");
                entity.Property(e => e.NgayCapNhat).HasColumnName("ngay_update").HasColumnType("datetime");
            });

            modelBuilder.Entity<Kho>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();  // Ensure Id is auto-incremented
                entity.Property(e => e.TenKho).HasColumnName("ten_kho").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.HienThi).HasColumnName("hien_thi").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.GhiChu).HasColumnName("ghi_chu").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.NguoiTao).HasColumnName("nguoi_tao").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.NgayTao).HasColumnName("ngay_tao").HasColumnType("datetime");
                entity.Property(e => e.NgayCapNhat).HasColumnName("cap_nhat").HasColumnType("datetime");
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();  // Ensure Id is auto-incremented
                entity.Property(e => e.TenNhaCungCap).HasColumnName("ten_ncc").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.HienThi).HasColumnName("hien_thi").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.TenDayDu).HasColumnName("ten_day_du").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.LoaiNCC).HasColumnName("loai_ncc").HasMaxLength(20).IsUnicode();
                entity.Property(e => e.Logo).HasColumnName("logo").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.NguoiDaiDien).HasColumnName("nguoi_dai_dien").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.SDT).HasColumnName("sdt").HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.TinhTrang).HasColumnName("tinh_trang").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.NVPhuTrach).HasColumnName("nv_phu_trach").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.GhiChu).HasColumnName("ghi_chu").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.NgayTao).HasColumnName("ngay_tao").HasColumnType("datetime");
                entity.Property(e => e.NgayCapNhat).HasColumnName("ngay_cap_nhat").HasColumnType("datetime");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();  // Ensure Id is auto-incremented
                entity.Property(e => e.TenSanPham).HasColumnName("ten_san_pham").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.HienThi).HasColumnName("hien_thi").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.NhomSanPham).HasColumnName("nhom_san_pham").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.HangSanXuat).HasColumnName("hang_sx").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.HinhAnh).HasColumnName("hinh_anh").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.DiaChi).HasColumnName("dia_chi").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.ThongTin).HasColumnName("thong_tin").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.HanSuDung).HasColumnName("han_su_dung").HasColumnType("datetime");
                entity.Property(e => e.QuyCach).HasColumnName("quy_cach").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.Dvt).HasColumnName("dvt").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.GiaNhap).HasColumnName("gia_nhap").HasColumnType("float");
                entity.Property(e => e.SLToiThieu).HasColumnName("sl_toi_thieu");
                entity.Property(e => e.SLToiDa).HasColumnName("sl_toi_da");
                entity.Property(e => e.SLNhap).HasColumnName("sl_nhap");
                entity.Property(e => e.SLXuat).HasColumnName("sl_xuat");
                entity.Property(e => e.SLTon).HasColumnName("sl_ton");
                entity.Property(e => e.TrangThai).HasColumnName("trang_thai").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.Ghichu).HasColumnName("ghi_chu").HasMaxLength(1000).IsUnicode();
                entity.Property(e => e.NgayTao).HasColumnName("ngay_tao").HasColumnType("datetime");
                entity.Property(e => e.NgayCapNhat).HasColumnName("ngay_cap_nhat").HasColumnType("datetime");
                entity.Property(e => e.NguoiTao).HasColumnName("nguoi_tao").HasMaxLength(255).IsUnicode();
            });

            modelBuilder.Entity<NhapKho>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();  // Ensure Id is auto-incremented
                entity.Property(e => e.LoaiNhap).HasColumnName("loai_nhap").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.NgayNhap).HasColumnName("ngay_nhap").HasColumnType("datetime");
                entity.Property(e => e.NhaCungCapId).HasColumnName("ncc_id");
                entity.Property(e => e.KhoId).HasColumnName("kho_id");
                entity.Property(e => e.SoLuongNhap).HasColumnName("sl_nhap");
                entity.Property(e => e.Nguoigiao).HasColumnName("nguoi_giao").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.NoiDungNhap).HasColumnName("noi_dung_nhap").HasMaxLength(1000).IsUnicode();
                entity.Property(e => e.NgayTao).HasColumnName("ngay_tao").HasColumnType("datetime");
                entity.Property(e => e.NgayCapNhat).HasColumnName("ngay_cap_nhat").HasColumnType("datetime");
                entity.Property(e => e.NguoiTao).HasColumnName("nguoi_tao").HasMaxLength(255).IsUnicode();
            });

            modelBuilder.Entity<NhapKhoCT>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();  // Ensure Id is auto-incremented
                entity.Property(e => e.NhapKhoId).HasColumnName("nhap_kho_id");
                entity.Property(e => e.NgayNhap).HasColumnName("ngay_nhap").HasColumnType("datetime");
                entity.Property(e => e.SanPhamId).HasColumnName("san_pham_id");
                entity.Property(e => e.NhomSanPham).HasColumnName("nhom_san_pham").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.HangXanXuat).HasColumnName("hang_sx").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.HinhAnh).HasColumnName("hinh_anh").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.ThongTin).HasColumnName("thong_tin").HasMaxLength(100).IsUnicode();
                entity.Property(e => e.HanSuDung).HasColumnName("han_su_dung").HasColumnType("datetime");
                entity.Property(e => e.QuyCach).HasColumnName("quy_cach").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.Dvt).HasColumnName("dvt").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.Solo).HasColumnName("so_lo").HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.GiaNhap).HasColumnName("gia_nhap").HasColumnType("float");
                entity.Property(e => e.SLNhap).HasColumnName("sl_nhap");
                entity.Property(e => e.SLXuat).HasColumnName("sl_xuat");
                entity.Property(e => e.SLTon).HasColumnName("sl_ton");
                entity.Property(e => e.NgayHetHan).HasColumnName("ngay_het_han").HasColumnType("datetime");
                entity.Property(e => e.Ghichu).HasColumnName("ghi_chu").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.NgayTao).HasColumnName("ngay_tao").HasColumnType("datetime");
                entity.Property(e => e.NgayCapNhat).HasColumnName("ngay_cap_nhat").HasColumnType("datetime");
                entity.Property(e => e.NguoiTao).HasColumnName("nguoi_tao").HasMaxLength(255).IsUnicode();
            });

            modelBuilder.Entity<XuatKho>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();  // Ensure Id is auto-incremented
                entity.Property(e => e.LoaiXuat).HasColumnName("loat_xuat").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.NgayXuat).HasColumnName("ngay_xuat").HasColumnType("datetime");
                entity.Property(e => e.NhanVienId).HasColumnName("nhan_vien_id");
                entity.Property(e => e.MaHoaDon).HasColumnName("ma_hoa_don").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.SlSanPham).HasColumnName("sl_san_pham");
                entity.Property(e => e.SlXuat).HasColumnName("sl_xuat");
                entity.Property(e => e.NoiDungXuat).HasColumnName("noi_dung_xuat").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.GhiChu).HasColumnName("ghi_chu").HasMaxLength(1000).IsUnicode();
                entity.Property(e => e.NgayTao).HasColumnName("ngay_tao").HasColumnType("datetime");
                entity.Property(e => e.NgayCapNhat).HasColumnName("ngay_cap_nhat").HasColumnType("datetime");
                entity.Property(e => e.NguoiTao).HasColumnName("nguoi_tao").HasMaxLength(255).IsUnicode();
            });

            modelBuilder.Entity<XuatKhoCT>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();  // Ensure Id is auto-incremented
                entity.Property(e => e.XuatKhoId).HasColumnName("xuat_kho_id");
                entity.Property(e => e.NgayXuat).HasColumnName("ngay_xuat").HasColumnType("datetime");
                entity.Property(e => e.SanPhamId).HasColumnName("san_pham_id");
                entity.Property(e => e.TenSanPham).HasColumnName("ten_san_pham").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.NhomSanPham).HasColumnName("nhom_san_pham").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.HangSanXuat).HasColumnName("hang_sx").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.HinhAnh).HasColumnName("hinh_anh").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.ThongTin).HasColumnName("thong_tin").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.QuyCach).HasColumnName("quy_cach").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.Dvt).HasColumnName("dvt").HasMaxLength(50).IsUnicode();
                entity.Property(e => e.SoLo).HasColumnName("so_lo").HasMaxLength(255).IsUnicode();
                entity.Property(e => e.NgayHetHan).HasColumnName("ngay_het_han").HasColumnType("datetime");
                entity.Property(e => e.SLXuat).HasColumnName("sl_xuat");
                entity.Property(e => e.SLXuatTong).HasColumnName("sl_xuat_tong");
                entity.Property(e => e.NgayTao).HasColumnName("ngay_tao").HasColumnType("datetime");
                entity.Property(e => e.NgayCapNhat).HasColumnName("ngay_cap_nhat").HasColumnType("datetime");
                entity.Property(e => e.NguoiTao).HasColumnName("nguoi_tao").HasMaxLength(250).IsUnicode();
            });

            // Define relationships
            modelBuilder.Entity<NhapKho>()
                .HasOne(nk => nk.NhaCungCap)
                .WithMany()
                .HasForeignKey(nk => nk.NhaCungCapId);

            modelBuilder.Entity<NhapKho>()
                .HasOne(nk => nk.Kho)
                .WithMany()
                .HasForeignKey(nk => nk.KhoId);

            modelBuilder.Entity<NhapKhoCT>()
                .HasOne(nkct => nkct.NhapKho)
                .WithMany()
                .HasForeignKey(nkct => nkct.NhapKhoId);

            modelBuilder.Entity<NhapKhoCT>()
                .HasOne(nkct => nkct.SanPham)
                .WithMany()
                .HasForeignKey(nkct => nkct.SanPhamId);

            modelBuilder.Entity<XuatKhoCT>()
                .HasOne(xkct => xkct.XuatKho)
                .WithMany()
                .HasForeignKey(xkct => xkct.XuatKhoId);

            modelBuilder.Entity<XuatKhoCT>()
                .HasOne(xkct => xkct.SanPham)
                .WithMany()
                .HasForeignKey(xkct => xkct.SanPhamId);
        }
    }
}
