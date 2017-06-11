using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities.DTO
{
    public class ServicioTuristicoDTO
    {
        public int ServicioTuristicoId { get; set; }
        public String Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Direccion { get; set; }
    }
}
