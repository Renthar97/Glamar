using Entidad;
using Entidad.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public class CiudadRepository : Repository<CIUDAD>, ICiudadRepository
    {
        public CiudadRepository(GlamarDbContext context) : base(context)
        {
        }

    }
}
