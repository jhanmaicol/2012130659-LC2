using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012130659_ENTStore.Entities.Entities
{
    public class ComprobantePago
    {
        public int ComprobantePagoId { get; set; }

        public TipoComprobante TipoComprobante { get; set; }

        public ComprobantePago()
        {
            TipoComprobante = new TipoComprobante();
        }

    }
}
