using System.ComponentModel.DataAnnotations;

namespace WebApiUsuarios.Dto.Usuario
{
    public class UsuarioEdicaoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Usuário")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Digite o Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Sobrenome")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }
    }
}
