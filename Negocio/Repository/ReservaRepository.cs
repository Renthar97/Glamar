using Entidad;
using Entidad.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public class ReservaRepository : Repository<RESERVA>, IReservaRepository
    {
        public ReservaRepository(GlamarDbContext context) : base(context)
        {
        }

    }
}