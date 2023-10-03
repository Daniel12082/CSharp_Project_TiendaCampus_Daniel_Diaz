using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class ClienteDireccionRepository : GenericRepository<ClienteDireccion>, IClienteDireccion
    {
        private readonly TiendaCampusContext _context;
        public ClienteDireccionRepository(TiendaCampusContext context) : base(context)
        {
            _context = context;
        }
    }
}