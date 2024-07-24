﻿using Microsoft.EntityFrameworkCore;
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
        }

        public ICongTyRepository CongTy { get; private set; }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
