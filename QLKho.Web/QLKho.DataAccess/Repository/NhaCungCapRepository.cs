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
        public void Update(NhaCungCap obj)
        {
            _db.NhaCungCaps.Update(obj);
        }
    }
}