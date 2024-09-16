using Corso.Entity.DAL;
using Corso.Entity.IRepositories;

namespace Corso.Entity.Repositories
{
    public class StudenteRepository : GenericRepository<Studente>, IStudenteRepository
    {
        public StudenteRepository(CorsoFormazioneContext context) : base(context) { }
    }
}
