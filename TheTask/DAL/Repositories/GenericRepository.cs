using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        TheTaskDbEntities _context;
        DbSet<TEntity> _dbSet;

        public GenericRepository(TheTaskDbEntities context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();          
        }

        public TEntity FindById(decimal id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);

            _context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;

            _context.SaveChanges();
        }
        public void Remove(decimal id)
        {
            var model = _dbSet.Find(id);

            _dbSet.Remove(model);
            _context.SaveChanges();
        }
    }
}
