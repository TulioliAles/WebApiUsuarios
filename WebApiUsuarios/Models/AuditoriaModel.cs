namespace WebApiUsuarios.Models
{
    public class AuditoriaModel
    {
        public int Id { get; set; }
        public string Acao { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public string UsuarioId { get; set; }
        public string DadosAlterados { get; set; }
    }
}
