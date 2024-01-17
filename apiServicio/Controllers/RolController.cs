using apiServicio.Models;
using apiServicio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace apiServicio.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RolController
    {
        private readonly IRolServices _IRolService;
        public RolController (IRolServices temp)
        {
            this._IRolService = temp;
        }
        [HttpGet]
        public async Task<List<Rol>> GetList()
        {
            return await _IRolService.GetList();
        }
        [HttpPost("AgregarActualizar")]
        public async Task<Rol> AgregarActualiza(int Id, string NombreRol, string t)
        {
            Rol l = new Rol();
            l.Id = Id;
            l.NombreRol = NombreRol;
            return await _IRolService.AgregarActualiza(l, t);
        }
    }
}
