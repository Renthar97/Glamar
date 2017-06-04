using Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Configurations
{
    public class TipoCorreoConfiguration : EntityTypeConfiguration<TIPOCORREO>
    {
        public TipoCorreoConfiguration()
        {
            ToTable("Tipo_Correo");
        }
    }
}
