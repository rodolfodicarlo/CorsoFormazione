using Corso.Entity.DAL;
using Corso.Entity.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Corso.Entity.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private CorsoFormazioneContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(CorsoFormazioneContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null,
                                                    Func<IQueryable<TEntity>,
                                                    IOrderedQueryable<TEntity>>? orderBy = null,
                                                    params string[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            else return await query.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByID(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual async Task<TEntity?> GetByID(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual async Task<TEntity> Insert(TEntity entity)
        {
            return (await _dbSet.AddAsync(entity)).Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _context.Update(entity).Entity;
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
