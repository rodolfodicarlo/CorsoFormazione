using System.Linq.Expressions;

namespace Corso.Entity.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null,
                               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                               params string[] includeProperties);
        Task<TEntity?> GetByID(int id);
        Task<TEntity?> GetByID(Guid id);
        Task<TEntity> Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        Task Save();
    }
}
