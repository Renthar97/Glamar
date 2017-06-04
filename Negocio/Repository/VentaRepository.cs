using Entidad;
using Entidad.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public class VentaRepository : Repository<VENTA>, IVentaRepository
    {
        public VentaRepository(GlamarDbContext context) : base(context)
        {
        }

    }
}
