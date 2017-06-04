using Entidad;
using Negocio.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GlamarDbContext : DbContext
    {
        public DbSet<ALOJAMIENTO> Alojamientos { get; set; }

        public DbSet<CLIENTE> Clientes { get; set; }

        public DbSet<CORREO> Correos { get; set; }

        public DbSet<DOCUMENTO> Documentos { get; set; }

        public DbSet<EMPLEADO> Empleados { get; set; }

        public DbSet<ITINERARIO> Itinerarios { get; set; }

        public DbSet<MONEDA> Monedas { get; set; }

        public DbSet<RESERVA> Reservas { get; set; }

        public DbSet<TELEFONO> Telefonos { get; set; }

        public DbSet<VENTA> Ventas { get; set; }

        public DbSet<TIPOTELEFONO> TTelefonos { get; set; }

        public DbSet<TIPOCORREO> TCorreos { get; set; }

        public DbSet<LOGIN> Logins { get; set; }

        public DbSet<HOTEL> Hoteles { get; set; }

        public DbSet<CIUDAD> Ciudades { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlojamientoConfiguration());
            modelBuilder.Configurations.Add(new CiudadConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new CorreoConfiguration());
            modelBuilder.Configurations.Add(new DocumentoConfiguration());
            modelBuilder.Configurations.Add(new EmpleadoConfiguration());
            modelBuilder.Configurations.Add(new HotelConfiguration());
            modelBuilder.Configurations.Add(new ItinerarioConfiguration());
            modelBuilder.Configurations.Add(new LoginConfiguration());
            modelBuilder.Configurations.Add(new MonedaConfiguration());
            modelBuilder.Configurations.Add(new ReservaConfiguration());
            modelBuilder.Configurations.Add(new TelefonoConfiguration());
            modelBuilder.Configurations.Add(new TipoCorreoConfiguration());
            modelBuilder.Configurations.Add(new TipoTelefonoConfiguration());
            modelBuilder.Configurations.Add(new VentaConfiguration());


            base.OnModelCreating(modelBuilder);
        }

    }
}
