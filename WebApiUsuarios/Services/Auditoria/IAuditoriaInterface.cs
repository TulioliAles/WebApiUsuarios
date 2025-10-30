using WebApiUsuarios.Models;

namespace WebApiUsuarios.Services.Auditoria
{
    public interface IAuditoriaInterface 
    {
        Task RegistrarAuditoriaAsync(string acao, string usuarioId, string dadosAlterados);
        Task<List<AuditoriaModel>> BuscarAuditorias();
    }
}
