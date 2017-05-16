using _2012130659_ENTStore.Entities.Entities;
using _2012130659_ENTStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012130659_PERStore.Persistence.Repositories
{
    public class CategoriaHospedajeRepository : Repository<CategoriaHospedaje>, ICategoriaHospedajeRepository
    {
        private readonly PaquetesTuristicoStoreDbContext _Context;

        public CategoriaHospedajeRepository(PaquetesTuristicoStoreDbContext context)
        {
            _Context = context;
        }
        private CategoriaHospedajeRepository()
        {

        }
    }
}
