using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities.DTO
{
    public class VentaPaqueteDTO
    {
        public int VentaPaqueteId { get; set; }


        //relaciones
        public int ComprobantePagoId { get; set; }
        public ComprobantePago ComprobantePago { get; set; }
        public MedioPago MediosPago { get; set; }
        }
}
