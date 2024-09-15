using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Entity.DAL;
using Corso.Entity.IRepositories;

namespace Corso.Entity.Repositories
{
    public class CorsoRepository : GenericRepository<CorsoEntity>, ICorsoRepository
    {
        public CorsoRepository(CorsoFormazioneContext context) : base(context)
        {
        }
    }
}
