using Microsoft.EntityFrameworkCore;
using QLKho.DataAccess.Data;
using QLKho.DataAccess.Repository.IRepository;
using QLKho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.DataAccess.Repository
{
    public class NhaCungCapRepository : Repository<NhaCungCap>, INhaCungCapRepository
    {
        private ApplicationDbContext _db;

        public NhaCungCapRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<NhaCungCap> Update(NhaCungCap nhaCungCap)
        {
            var existingNhaCungCap = await _db.NhaCungCaps.FirstOrDefaultAsync(x => x.Id == nhaCungCap.Id);

            if (existingNhaCungCap != null)
            {
                _db.Entry(existingNhaCungCap).CurrentValues.SetValues(nhaCungCap);
                await _db.SaveChangesAsync();
                return existingNhaCungCap;  // Return the updated entity from the database
            }

            return null;  // Return null if the entity with the specified ID was not found
        }

       
    }
}