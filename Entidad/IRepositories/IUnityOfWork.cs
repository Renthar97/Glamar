using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.IRepositories
{
    //Debe heredar de IDisposable para que el Garbage Collector
    //pueda liberar memoria que ya no utilice.
    public interface IUnityOfWork : IDisposable
    {
        //Cada una de las propiedades deben ser de solo lectura
        IAlojamientoRepository Alojamientos { get; }
        ICiudadRepository Ciudades { get; }
        IClienteRepository Clientes { get; }
        ICorreoRepository Correos { get; }
        IDocumentoRepository Documentos { get; }
        IEmpleadoRepository Empleados { get; }
        IHotelRepository Hoteles { get; }
        IItinerarioRepository Itinerarios { get; }
        ILoginRepository Logins { get; }
        IMonedaRepository Monedas { get; }
        IReservaRepository Reservas { get; }
        ITelefonoRepository Telefonos { get; }
        ITipoCorreoRepository TCorreos { get; }
        ITipoTelefonoRepository TTelefonos { get; }
        IVentaRepository Ventas { get; }

        //Método que guardará los cambios en la base de datos.
        int SaveChanges();

        void StateModified(object entity);
    }
}
