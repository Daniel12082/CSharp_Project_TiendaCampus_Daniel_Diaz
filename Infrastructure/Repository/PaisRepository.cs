using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PaisRepository : GenericRepository<Pais>, IPais
{
    private readonly TiendaCampusContext _context;
    public PaisRepository(TiendaCampusContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.Paises.Include(p => p.Departamentos).ThenInclude(c=> c.Ciudades).ToListAsync();
    }

    public async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.Paises.Include(p => p.Departamentos).ThenInclude(c=> c.Ciudades).AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }
        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include( u => u.Departamentos).Skip((pageIndex-1)*pageSize).Take(pageSize).ToListAsync();
        return (totalRegistros, registros);
    }
}
    

