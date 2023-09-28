using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class PaisRepository : GenericRepository<Pais>, IPais
{
    private readonly TiendaCampusContext _context;
    public PaisRepository(TiendaCampusContext context) : base(context)
    {
        _context = context;
    }
}
