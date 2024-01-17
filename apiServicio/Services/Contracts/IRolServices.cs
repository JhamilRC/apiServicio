using apiServicio.Models;

namespace apiServicio.Services.Contracts
{
    public interface IRolServices
    {
        Task<Rol> AgregarActualiza(Rol l, string t);
        Task<List<Rol>> GetList();
    }
}
