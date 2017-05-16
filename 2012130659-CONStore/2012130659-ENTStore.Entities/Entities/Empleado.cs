using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012130659_ENTStore.Entities.Entities
{
    public class Empleado : Persona
    {
        public int EmpleadoId { get; set; }
        public DateTime FechaIng { get; set; }
        public string Password { get; set; }
        public double Salario { get; set; }
        public string Usuario { get; set; }
    }
}
