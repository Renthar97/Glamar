using Entidad;
using Entidad.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public class TipoCorreoRepository : Repository<TIPOCORREO>, ITipoCorreoRepository
    {
        public TipoCorreoRepository(GlamarDbContext context) : base(context)
        {
        }

    }
}