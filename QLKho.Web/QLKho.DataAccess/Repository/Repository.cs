using Microsoft.EntityFrameworkCore;
using QLKho.DataAccess.Data;
using QLKho.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QLKho.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            /* await dbSet.AddAsync(entity);
             await _db.SaveChangesAsync();
             return entity;*/
            // Thêm đối tượng vào DbSet
            var addedEntity = await dbSet.AddAsync(entity);

            // Lưu các thay đổi vào cơ sở dữ liệu
            await _db.SaveChangesAsync();

            // Trả về đối tượng đã được thêm vào cơ sở dữ liệu
            return addedEntity.Entity;
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string includeProperties = null, bool tracked = true)
        {
            IQueryable<T> query = tracked ? dbSet : dbSet.AsNoTracking();

            query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task Remove(T entity)
        {
            dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
