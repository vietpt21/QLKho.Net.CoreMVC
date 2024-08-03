using Microsoft.EntityFrameworkCore;
using QLKho.DataAccess.Data;
using QLKho.DataAccess.Repository.IRepository;
using QLKho.Models;
using System.Threading.Tasks;

namespace QLKho.DataAccess.Repository
{
    public class SanPhamRepository : Repository<SanPham>, ISanPhamRepository
    {
        private ApplicationDbContext _db;

        public SanPhamRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<SanPham> Update(SanPham sanPham)
        {
            var existing = await _db.SanPhams.FirstOrDefaultAsync(x => x.Id == sanPham.Id);

            if (existing != null)
            {
                _db.Entry(existing).CurrentValues.SetValues(sanPham);
                await _db.SaveChangesAsync();
                return existing;  // Return the updated entity from the database
            }

            return null;  // Return null if the entity with the specified ID was not found
        }
    }
}
