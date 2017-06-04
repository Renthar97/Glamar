using Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Configurations
{
    public class ItinerarioConfiguration : EntityTypeConfiguration<ITINERARIO>
    {
        public ItinerarioConfiguration()
        {
            ToTable("Itinerario");
        }
    }
}
