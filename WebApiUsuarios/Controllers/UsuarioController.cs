using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiUsuarios.Dto.Usuario;
using WebApiUsuarios.Services.Usuario;

namespace WebApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;

        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios() 
        { 
            var usuarios = await _usuarioInterface.ListarUsuarios();

            return Ok(usuarios);
        }

        [HttpGet("id")]
        public async Task<IActionResult> BuscarUsuario(int id)
        {
            var usuario = await _usuarioInterface.BuscarUsuario(id);

            return Ok(usuario);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> RemoverUsuario(int id)
        {
            var usuario = await _usuarioInterface.RemoverUsuario(id);

            return Ok(usuario);
        }

        [HttpPut]
        public async Task<IActionResult> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto)
        {
            var usuario = await _usuarioInterface.EditarUsuario(usuarioEdicaoDto);

            return Ok(usuario);
        }
    }
}
