using _2012130659_ENTStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012130659_PERStore.Persistence.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly PaquetesTuristicoStoreDbContext _Context;
        private static UnityOfWork _Instance;
        private static readonly object _Lock = new object();

        public IAlimentacionRepository Alimentaciones { get; private set; }
        public ICalificacionHospedajeRepository CalificacionHospedajes { get; private set; }
        public ICategoriaAlimentacionRepository CategoriaAlimentaciones { get; private set; }
        public ICategoriaHospedajeRepository CategoriaHospedajes { get; private set; }
        public ICategoriaTransporteRepository CategoriaTransportes { get; private set; }
        public IClienteRepository Clientes { get; private set; }
        public IComprobantePagoRepository ComprobantePagos  { get; private set; }
        public IEmpleadoRepository Empleados { get; private set; }
        public IHospedajeRepository Hospedajes { get; private set; }
        public IMedioPagoRepository MedioPagos { get; private set; }
        public IPaqueteRepository Paquetes { get; private set; }
        public IPersonaRepository Personas { get; private set; }
        public IServicioHospedajeRepository ServicioHospedajes { get; private set; }
        public IServicioTuristicoRepository ServicioTuristicos { get; private set; }
        public ITipoComprobanteRepository TipoComprobantes { get; private set; }
        public ITipoHospedajeRepository TipoHospedajes { get; private set; }
        public ITipoTransporteRepository TipoTransportes { get; private set; }
        public ITransporteRepository Transportes { get; private set; }
        public IVentaPaqueteRepository VentaPaquetes { get; private set; }

        private UnityOfWork()
        {
            _Context = new PaquetesTuristicoStoreDbContext();

            Alimentaciones = new AlimentacionRepository(_Context);
            CalificacionHospedajes = new CalificacionHospedajeRepository(_Context);
            CategoriaAlimentaciones = new CategoriaAlimentacionRepository(_Context);
            CategoriaHospedajes = new CategoriaHospedajeRepository(_Context);
            CategoriaTransportes = new CategoriaTransporteRepository(_Context);
            Clientes = new ClienteRepository(_Context);
            ComprobantePagos = new ComprobantePagoRepository(_Context);
            Empleados = new EmpleadoRepository(_Context);
            Hospedajes = new HospedajeRepository(_Context);
            MedioPagos = new MedioPagoRepository(_Context);
            Paquetes = new PaqueteRepository(_Context);
            Personas = new PersonaRepository(_Context);
            ServicioHospedajes = new ServicioHospedajeRepository(_Context);
            ServicioTuristicos = new ServicioTuristicoRepository(_Context);
            TipoComprobantes = new TipoComprobanteRepository(_Context);
            TipoHospedajes = new TipoHospedajeRepository(_Context);
            TipoTransportes = new TipoTransporteRepository(_Context);
            Transportes = new TransporteRepository(_Context);
            VentaPaquetes = new VentaPaqueteRepository(_Context);
            
        }

        public static UnityOfWork Instance
        {
            get
            {
                lock (_Lock)
                {
                    if (_Instance == null)
                        _Instance = new UnityOfWork();
                }

                return _Instance;
            }
        }


        public void Dispose()
        {
            _Context.Dispose();
        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }
    }
}
