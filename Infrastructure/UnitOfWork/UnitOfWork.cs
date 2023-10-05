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
        private ICita _citas;
        private ICiudad _ciudades;
        private ICliente _clientes;
        private IClienteDireccion _clienteDireccion;
        private IClienteTelefono _clienteTelefono;
        private IDepartamento _departamentos;
        private IMascota _mascotas;
        private IPais _paises;
        private IRaza _razas;
        private IServicio _servicios;
        private ITipoDocumento _tipoDocumentos;
        public UnitOfWork(TiendaCampusContext context)
        {
            _context = context;
        }
        public ICita Cita{
            get{
                if(_citas == null){
                    _citas = new CitaRepository(_context);
                }
                return _citas;
            }
        }
        public ICiudad Ciudad{
            get{
                if(_ciudades == null){
                    _ciudades = new CiudadRepository(_context);
                }
                return _ciudades;
            }
        }
        public ICliente Cliente{
            get{
                if(_clientes == null){
                    _clientes = new ClienteRepository(_context);
                }
                return _clientes;
            }
        }
        public IClienteDireccion ClienteDireccion{
            get{
                if(_clienteDireccion == null){
                    _clienteDireccion = new ClienteDireccionRepository(_context);
                }
                return _clienteDireccion;
            }
        }
        public IClienteTelefono ClienteTelefono{
            get{
                if(_clienteTelefono == null){
                    _clienteTelefono = new ClienteTelefonoRepository(_context);
                }
                return _clienteTelefono;
            }
        }
        public IDepartamento Departamento{
            get{
                if(_departamentos == null){
                    _departamentos = new DepartamentoRepository(_context);
                }
                return _departamentos;
            }
        }
        public IMascota Mascota{
            get{
                if(_mascotas == null){
                    _mascotas = new MascotaRepository(_context);
                }
                return _mascotas;
            }
        }
        public IPais Pais{
            get{
                if(_paises == null){
                    _paises = new PaisRepository(_context);
                }
                return _paises;
            }
        }
        public IRaza Raza{
            get{
                if(_razas == null){
                    _razas = new RazaRepository(_context);
                }
                return _razas;
            }
        }
        public IServicio Servicio{
            get{
                if(_servicios == null){
                    _servicios = new ServicioRepository(_context);
                }
                return _servicios;
            }
        }
        public ITipoDocumento TipoDocumento{
            get{
                if(_tipoDocumentos == null){
                    _tipoDocumentos = new TipoDocumentoRepository(_context);
                }
                return _tipoDocumentos;
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