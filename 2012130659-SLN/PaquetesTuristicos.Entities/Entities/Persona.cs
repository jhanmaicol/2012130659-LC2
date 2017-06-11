using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities
{
    public abstract class Persona
    {
        public int PersonaId { get; set; }

        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Dirección { get; set; }
        public int NumeroDni { get; set; }

        
    }
}
