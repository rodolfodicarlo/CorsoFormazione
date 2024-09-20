using Corso.Entity.DAL;
using Corso.Entity.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Corso.Entity.Repositories
{
    public class StudenteRepository : GenericRepository<Studente>, IStudenteRepository
    {
        //private DbSet<Studente> _dbSet;
        public StudenteRepository(CorsoFormazioneContext context) : base(context) 
        {
            //_dbSet = context.Set<Studente>();
        }

        //public virtual string RecuperaUltimaMatricola()
        //{
        //    return _dbSet.OrderBy(s => s.Matricola).LastOrDefault().Matricola;
        //}
    }
}
