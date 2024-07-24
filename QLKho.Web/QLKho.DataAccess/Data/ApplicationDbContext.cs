using Microsoft.EntityFrameworkCore;
using QLKho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
