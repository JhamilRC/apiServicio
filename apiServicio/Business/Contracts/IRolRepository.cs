using System.Collections.Generic;
using apiServicio.Models;
using System;
using System.Linq;


namespace apiServicio.Business.Contracts
{
    public interface IRolRepository
    {
        Task<List<Rol>> GetList();
        Task<Rol> AgregarActualiza(Rol l, string t);
    }
}
