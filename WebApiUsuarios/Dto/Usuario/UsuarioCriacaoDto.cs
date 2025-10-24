using System.ComponentModel.DataAnnotations;

namespace WebApiUsuarios.Dto.Usuario
{
    public class UsuarioCriacaoDto
    {
        [Required(ErrorMessage ="Digite o Usuário")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Digite o Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Sobrenome")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteração { get; set; }
        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Digite a Confirmação de Senha"), 
            Compare("Senha")]
        public string ConfirmaSenha { get; set; }
    }
}
