using Corso.Entity.DAL;
using Corso.Entity.IRepositories;
using Corso.Entity.Repositories;

namespace Corso.Entity.IUnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CorsoFormazioneContext _context;
        private bool _disposed;

        public IAulaRepository AulaRepository { get; private set; }
        public IDocenteRepository DocenteRepository { get; private set; }
        public IStudenteRepository StudenteRepository { get; private set; }
        public ICorsoRepository CorsoRepository { get; private set; }

        public UnitOfWork(CorsoFormazioneContext context)
        {
            _context = context;

            AulaRepository = new AulaRepository(context);
            DocenteRepository = new DocenteRepository(context);
            StudenteRepository = new StudenteRepository(context);
            CorsoRepository = new CorsoRepository(context);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
