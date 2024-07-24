using Microsoft.EntityFrameworkCore;
using QLKho.DataAccess.Data;
using QLKho.DataAccess.Repository.IRepository;
using QLKho.Models;
using System.Threading.Tasks;

namespace QLKho.DataAccess.Repository
{
    public class CongTyRepository : Repository<CongTy>, ICongTyRepository
    {
        private ApplicationDbContext _db;

        public CongTyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<CongTy> Update(CongTy congTy)
        {
            var existingCongTy = await _db.CongTies.FirstOrDefaultAsync(x => x.Id == congTy.Id);

            if (existingCongTy != null)
            {
                _db.Entry(existingCongTy).CurrentValues.SetValues(congTy);
                await _db.SaveChangesAsync();
                return existingCongTy;  // Return the updated entity from the database
            }

            return null;  // Return null if the entity with the specified ID was not found
        }
    }
}
