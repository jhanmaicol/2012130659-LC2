using _2012130659_ENTStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012130659_ENTStore.Entities.IRepositories
{
    public interface IAlimentacionRepository : IRepository<Alimentacion>
    {
        
        IEnumerable<Alimentacion> GetAlimentacionWithMovies(int pagaIndex, int pageSize);

        IEnumerable<Alimentacion> GetAlimentacionByClassification(CategoriaAlimentacion categoriaAlimentacion);
    }
}
