using Corso.Entity.DAL;
using Corso.Entity.IRepositories;

namespace Corso.Entity.Repositories
{
    internal class CorsoRepository : GenericRepository<DAL.Corso>, ICorsoRepository
    {
        public CorsoRepository(CorsoFormazioneContext context) : base(context)
        {
        }
    }
}
