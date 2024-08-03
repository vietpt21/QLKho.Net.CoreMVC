using Microsoft.EntityFrameworkCore;
using QLKho.DataAccess.Data;
using QLKho.DataAccess.Repository.IRepository;
using QLKho.Models;
using System.Threading.Tasks;

namespace QLKho.DataAccess.Repository
{
    public class KhoRepository : Repository<Kho>, IKhoRepository
    {
        private ApplicationDbContext _db;

        public KhoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Kho> Update(Kho kho)
        {
            var existingKho = await _db.Khos.FirstOrDefaultAsync(x => x.Id == kho.Id);

            if (existingKho != null)
            {
                _db.Entry(existingKho).CurrentValues.SetValues(kho);
                await _db.SaveChangesAsync();
                return existingKho;  // Return the updated entity from the database
            }

            return null;  // Return null if the entity with the specified ID was not found
        }
    }
}
