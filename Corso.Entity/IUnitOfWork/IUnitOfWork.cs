using Corso.Entity.IRepositories;

namespace Corso.Entity.IUnitOfWork
{
    public interface IUnitOfWork
    {
        public IAulaRepository AulaRepository { get; }
        public IDocenteRepository DocenteRepository { get; }
        public IStudenteRepository StudenteRepository { get; }
        public ICorsoRepository CorsoRepository { get; }
        public void Dispose();
        public Task Save();
    }
}
