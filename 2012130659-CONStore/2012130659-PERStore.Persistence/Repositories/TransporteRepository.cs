using _2012130659_ENTStore.Entities.Entities;
using _2012130659_ENTStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012130659_PERStore.Persistence.Repositories
{
    public class TransporteRepository : Repository<Transporte>, ITransporteRepository
    {
        private readonly PaquetesTuristicoStoreDbContext _Context;

        public TransporteRepository(PaquetesTuristicoStoreDbContext context)
        {
            _Context = context;
        }
        private TransporteRepository()
        {

        }
    }
}
