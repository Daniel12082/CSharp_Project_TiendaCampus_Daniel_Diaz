using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class TipoDocumentoRepository : GenericRepository<TipoDocumento>
    {
        private readonly TiendaCampusContext _context;

        public TipoDocumentoRepository(TiendaCampusContext context) : base(context)
        {
            _context = context;
        }
    }
}