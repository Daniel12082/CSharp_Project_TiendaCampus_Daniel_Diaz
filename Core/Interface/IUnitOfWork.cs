using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interface;

    public interface IUnitOfWork
    {   
        ICita Cita { get; }
        ICiudad Ciudad { get; }
        ICliente Cliente { get; }
        IClienteDireccion ClienteDireccion { get; }
        IClienteTelefono ClienteTelefono { get; }
        IDepartamento Departamento { get; }
        IMascota Mascota { get; }
        IPais Pais { get; }
        IRaza Raza { get; }
        IServicio Servicio { get; }
        ITipoDocumento TipoDocumento { get; }

        Task<int> SaveAsync();
    }
