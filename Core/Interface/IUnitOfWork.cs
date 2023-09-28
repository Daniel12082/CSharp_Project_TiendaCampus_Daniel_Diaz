using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IUnitOfWork
    {
        ICiudad Ciudades {get;}
        IDepartamento Departamentos {get;}
        IPais Paises {get;}
        Task<int> SaveAsync();
    }
}