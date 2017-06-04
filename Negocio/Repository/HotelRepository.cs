using Entidad;
using Entidad.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public class HotelRepository : Repository<HOTEL>, IHotelRepository
    {
        public HotelRepository(GlamarDbContext context) : base(context)
        {
        }

    }
}