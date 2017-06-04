using Entidad;
using Entidad.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public class LoginRepository : Repository<LOGIN>, ILoginRepository
    {
        public LoginRepository(GlamarDbContext context) : base(context)
        {
        }

    }
}
