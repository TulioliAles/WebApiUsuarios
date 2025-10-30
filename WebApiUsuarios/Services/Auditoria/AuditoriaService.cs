using Microsoft.EntityFrameworkCore;
using WebApiUsuarios.Data;
using WebApiUsuarios.Models;

namespace WebApiUsuarios.Services.Auditoria
{
    public class AuditoriaService : IAuditoriaInterface
    {
        private readonly AppDbContext _context;

        public AuditoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AuditoriaModel>> BuscarAuditorias()
        {
            var auditorias = await _context.Auditorias.OrderByDescending(x => x.Data).ToListAsync();
            return auditorias;
        }

        public async Task RegistrarAuditoriaAsync(string acao, string usuarioId, string dadosAlterados)
        {
            var auditoria = new AuditoriaModel
            {
                Acao = acao,
                DadosAlterados = dadosAlterados,
                UsuarioId = usuarioId
            };

            _context.Auditorias.Add(auditoria);
            await _context.SaveChangesAsync();
        }
    }
}
