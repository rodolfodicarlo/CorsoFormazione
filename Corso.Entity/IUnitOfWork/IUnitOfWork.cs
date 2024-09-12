using Corso.Entity.IRepositories;

namespace Corso.Entity.IUnitOfWork
{
    public interface IUnitOfWork
    {
        public IAulaRepository AulaRepository { get; }
        public void Dispose();
        public Task Save();
    }
}
