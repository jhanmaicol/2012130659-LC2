using _2012130659_ENTStore.Entities.Entities;
using _2012130659_ENTStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012130659_PERStore.Persistence.Repositories
{
    public class AlimentacionRepository : Repository<Alimentacion>, IAlimentacionRepository
    {
        private readonly PaquetesTuristicoStoreDbContext _Context;

        private AlimentacionRepository()
        {

        }

        public AlimentacionRepository(PaquetesTuristicoStoreDbContext context)
        {
            _Context = context;
        }

        IEnumerable<Alimentacion> IAlimentacionRepository.GetAlimentacionByClassification(CategoriaAlimentacion categoriaAlimentacion)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Alimentacion> IAlimentacionRepository.GetAlimentacionWithMovies(int pagaIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
