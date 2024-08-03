using Microsoft.EntityFrameworkCore;
using QLKho.DataAccess.Data;
using QLKho.DataAccess.Repository.IRepository;
using QLKho.Models;
using System.Threading.Tasks;

namespace QLKho.DataAccess.Repository
{
    public class NhapKhoRepository : Repository<NhapKho>, INhapKhoRepository
    {
        private ApplicationDbContext _db;

        public NhapKhoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<NhapKho> Update(NhapKho nhapKho)
        {
            var existingNhapKho = await _db.NhapKhos.FirstOrDefaultAsync(x => x.Id == nhapKho.Id);

            if (existingNhapKho != null)
            {
                _db.Entry(existingNhapKho).CurrentValues.SetValues(nhapKho);
                await _db.SaveChangesAsync();
                return existingNhapKho;  // Return the updated entity from the database
            }

            return null;  // Return null if the entity with the specified ID was not found
        }
    }
}
