using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012130659_ENTStore.Entities.Entities
{
    public class Cliente : Persona
    {
        public int ClienteId { get; set; }
        public int NumTarjeta { get; set; }
    }
}
