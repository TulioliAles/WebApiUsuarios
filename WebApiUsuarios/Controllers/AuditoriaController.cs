using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiUsuarios.Services.Auditoria;

namespace WebApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuditoriaController : ControllerBase
    {
        private readonly IAuditoriaInterface _auditoriaInterface;

        public AuditoriaController(IAuditoriaInterface auditoriaInterface)
        {
            _auditoriaInterface = auditoriaInterface;
        }

        [HttpGet("Auditoria")]
        public async Task<IActionResult> BuscarAuditorias()
        {
            var auditorias = _auditoriaInterface.BuscarAuditorias();
            return Ok(auditorias);
        }
    }
}
