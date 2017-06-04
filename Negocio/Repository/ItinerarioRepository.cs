using Entidad;
using Entidad.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public class ItinerarioRepository : Repository<ITINERARIO>, IItinerarioRepository
    {
        public ItinerarioRepository(GlamarDbContext context) : base(context)
        {
        }

    }
}