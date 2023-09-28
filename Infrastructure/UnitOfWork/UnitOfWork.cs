using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TiendaCampusContext _context;
        private ICiudad _ciudades;
        private IDepartamento _departamentos;
        private IPais _paises;
        public UnitOfWork(TiendaCampusContext context)
        {
            _context = context;
        }
        public IPais Paises{
            get{
                if(_paises == null){
                    _paises = new PaisRepository(_context);
                }
                return _paises;
            }
        }
        public IDepartamento Departamentos{
            get{
                if(_departamentos == null){
                    _departamentos = new DepartamentoRepository(_context);
                }
                return _departamentos;
            }
        }
        public ICiudad Ciudades{
            get{
                if(_ciudades == null){
                    _ciudades = new CiudadRepository(_context);
                }
                return _ciudades;
            }
        }
        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}