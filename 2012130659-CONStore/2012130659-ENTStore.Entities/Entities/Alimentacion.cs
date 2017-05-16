using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012130659_ENTStore.Entities.Entities
{
   public class Alimentacion : ServicioTuristico 
    {
        public int AlimentacionId { get; set; }

        public CategoriaAlimentacion Categoria { get; set; }

        public Alimentacion()
        {
            Categoria = new CategoriaAlimentacion();
        }


    }
}
