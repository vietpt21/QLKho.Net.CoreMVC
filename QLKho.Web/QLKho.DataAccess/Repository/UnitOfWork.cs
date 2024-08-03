using Microsoft.EntityFrameworkCore;
using QLKho.DataAccess.Data;
using QLKho.DataAccess.Repository.IRepository;
using System.Threading.Tasks;

namespace QLKho.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CongTy = new CongTyRepository(_db);
            NhaCungCap = new NhaCungCapRepository(_db);
            Kho = new KhoRepository(_db);
            NhapKho = new NhapKhoRepository(_db);
            SanPham = new SanPhamRepository(_db);
        }

        public ICongTyRepository CongTy { get; private set; }
        public INhaCungCapRepository NhaCungCap { get; private set; }
        public IKhoRepository Kho { get; private set; }
        public INhapKhoRepository NhapKho { get; private set; }
        public ISanPhamRepository SanPham { get; private set; }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
