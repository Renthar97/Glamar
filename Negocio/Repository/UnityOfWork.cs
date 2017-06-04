using Entidad.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        //variable que contendra el contexto de la base de datos
        private readonly GlamarDbContext _Context;
        public static UnityOfWork Instance;

        public IAlojamientoRepository Alojamientos { get; private set; }
        public ICiudadRepository Ciudades { get; private set; }
        public IClienteRepository Clientes { get; private set; }
        public ICorreoRepository Correos { get; private set; }
        public IDocumentoRepository Documentos { get; private set; }
        public IEmpleadoRepository Empleados { get; private set; }
        public IHotelRepository Hoteles { get; private set; }
        public IItinerarioRepository Itinerarios { get; private set; }
        public ILoginRepository Logins { get; private set; }
        public IMonedaRepository Monedas { get; private set; }
        public IReservaRepository Reservas { get; private set; }
        public ITelefonoRepository Telefonos { get; private set; }
        public ITipoCorreoRepository TCorreos { get; private set; }
        public ITipoTelefonoRepository TTelefonos { get; private set; }
        public IVentaRepository Ventas { get; private set; }

        public UnityOfWork()
        {

        }

        public UnityOfWork(GlamarDbContext context)
        {
            //Se crea un unico contexto de base de datos
            //para apuntar todos los repositorios a la misma base de datos
            _Context = context;

            Alojamientos = new AlojamientoRepository(_Context);
            Ciudades = new CiudadRepository(_Context);
            Clientes = new ClienteRepository(_Context);
            Correos = new CorreoRepository(_Context);
            Documentos = new DocumentoRepository(_Context);
            Empleados = new EmpleadoRepository(_Context);
            Hoteles = new HotelRepository(_Context);
            Itinerarios = new ItinerarioRepository(_Context);
            Logins = new LoginRepository(_Context);
            Monedas = new MonedaRepository(_Context);
            Reservas = new ReservaRepository(_Context);
            Telefonos = new TelefonoRepository(_Context);
            TCorreos = new TipoCorreoRepository(_Context);
            TTelefonos = new TipoTelefonoRepository(_Context);
            Ventas = new VentaRepository(_Context);

        }

        public void Dispose()
        {
            _Context.Dispose();
        }

        //metodo que guarda los cambios. lleva los cambios en memoria hacia la base de datos.
        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        //metodo que cambia el estado de una entidad en el entityframework para que luego se cambie en la base de datos
        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
