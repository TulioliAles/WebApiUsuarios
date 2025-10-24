namespace WebApiUsuarios.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string  Nome { get; set;}
        public string Sobrenome { get; set;}
        public string Email { get; set;}
        public string Token { get; set;} = string.Empty;
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteração { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
    }
}
