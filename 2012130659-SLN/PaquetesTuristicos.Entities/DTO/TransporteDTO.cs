using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities.DTO
{
   public class TransporteDTO : ServicioTuristicoDTO
    {
        public string DescripcionTransporte { get; set; }

       
        public TipoTransporte TipoTransporte { get; set; }
        public CategoriaTransporte CategoriaTransporte { get; set; }

    }
}
