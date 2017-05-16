using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012130659_ENTStore.Entities.IRepositories
{
    public interface IUnityOfWork : IDisposable
    {
        IAlimentacionRepository Alimentaciones { get; }
        ICalificacionHospedajeRepository CalificacionHospedajes { get; }
        ICategoriaAlimentacionRepository CategoriaAlimentaciones { get; }
        ICategoriaHospedajeRepository CategoriaHospedajes { get; }
        ICategoriaTransporteRepository CategoriaTransportes { get; }
        IClienteRepository Clientes { get; }
        IComprobantePagoRepository ComprobantePagos { get; }
        IEmpleadoRepository Empleados { get; }
        IHospedajeRepository Hospedajes { get; }
        IMedioPagoRepository MedioPagos { get; }
        IPaqueteRepository Paquetes { get; }
        IPersonaRepository Personas { get; }
        IServicioHospedajeRepository ServicioHospedajes { get; }
        IServicioTuristicoRepository ServicioTuristicos { get; }
        ITipoComprobanteRepository TipoComprobantes { get; }
        ITipoHospedajeRepository TipoHospedajes { get; }
        ITipoTransporteRepository TipoTransportes { get; }
        ITransporteRepository Transportes { get; }
        IVentaPaqueteRepository VentaPaquetes { get; }

        int SaveChanges();

    }
}
