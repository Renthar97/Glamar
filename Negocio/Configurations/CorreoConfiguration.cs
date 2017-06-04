using Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Configurations
{
    public class CorreoConfiguration : EntityTypeConfiguration<CORREO>
    {
        public CorreoConfiguration()
        {
            ToTable("Correo");
        }
    }
}
