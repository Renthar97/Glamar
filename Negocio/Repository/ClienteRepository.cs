using Entidad;
using Entidad.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public class ClienteRepository : Repository<CLIENTE>, IClienteRepository
    {
        public ClienteRepository(GlamarDbContext context) : base(context)
        {
        }

    }
}
