using Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Configurations
{
    public class TipoTelefonoConfiguration : EntityTypeConfiguration<TIPOTELEFONO>
    {
        public TipoTelefonoConfiguration()
        {
            ToTable("Tipo_Telefono");
        }
    }
}
