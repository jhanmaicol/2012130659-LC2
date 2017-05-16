using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012130659_ENTStore.Entities.Entities
{
    public class Transporte : ServicioTuristico
    {
        public int MyProTransporteId { get; set; }

        public TipoTransporte Tipo { get; set; }
        public CategoriaTransporte Categoria { get; set; }

        public Transporte()
        {
            Tipo = new TipoTransporte();
            Categoria = new CategoriaTransporte();
        }
    }
}
