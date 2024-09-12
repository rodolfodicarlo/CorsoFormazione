using Corso.Entity.DAL;
using Corso.Entity.IRepositories;

namespace Corso.Entity.Repositories
{
    public class AulaRepository : GenericRepository<Aula>, IAulaRepository
    {
        public AulaRepository(CorsoFormazioneContext context) : base(context)
        {

        }
    }
}
