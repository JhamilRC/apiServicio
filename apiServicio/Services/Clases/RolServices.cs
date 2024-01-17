using apiServicio.Models;
using apiServicio.Services.Contracts;
using apiServicio.Business.Contracts;

namespace apiServicio.Services.Clases
{
    public class RolServices: IRolServices
    {
        private readonly IRolRepository _IRolRepository;
        public RolServices(IRolRepository temp)
        {
            _IRolRepository = temp;
        }
        public Task<List<Rol>> GetList()
        {
            return _IRolRepository.GetList();
        }
        public Task<Rol> AgregarActualiza(Rol l, string t)
        {
            return _IRolRepository.AgregarActualiza(l, t);
        }
    }
}
