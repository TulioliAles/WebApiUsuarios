using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiUsuarios.Data;
using WebApiUsuarios.Dto.Usuario;
using WebApiUsuarios.Models;
using WebApiUsuarios.Services.Senha;

namespace WebApiUsuarios.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        private readonly ISenhaInterface _senhaInterface;
        private readonly IMapper _mapper;

        public UsuarioService(AppDbContext context, ISenhaInterface senhaInterface, IMapper mapper)
        {
            _context = context;
            _senhaInterface = senhaInterface;
            _mapper = mapper;
        }


        public async Task<ResponseModel<UsuarioModel>> BuscarUsuario(int id)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                if (usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado!";

                    return response;
                }

                response.Dados = usuario;
                response.Mensagem = "Usuário localizado com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {   
                UsuarioModel usuarioBanco = await _context.Usuarios.FindAsync(usuarioEdicaoDto.Id);

                if(usuarioBanco == null)
                {
                    response.Mensagem = "Usuário não localizado";
                    response.Status = false;

                    return response;
                }

                usuarioBanco.Nome = usuarioEdicaoDto.Nome;
                usuarioBanco.Sobrenome = usuarioEdicaoDto.Sobrenome;
                usuarioBanco.Email = usuarioEdicaoDto.Email;
                usuarioBanco.Usuario = usuarioEdicaoDto.Usuario;
                usuarioBanco.DataAlteração = DateTime.Now;

                _context.Update(usuarioBanco);
                await _context.SaveChangesAsync();

                response.Mensagem = "Usuário editado com sucesso!";
                response.Dados = usuarioBanco;

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuarioModel>> response = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                if (usuarios.Count == 0) 
                {
                    response.Mensagem = "Nenhum Usuário cadastrado!";

                    return response;
                }

                response.Dados = usuarios;
                response.Mensagem = "Usuários localizados com sucesso!";
                
                return response;
            }
            catch (Exception ex) 
            { 
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {                 
                if (!VerificaExistenciaEmailUsuario(usuarioCriacaoDto))
                {
                    response.Mensagem = "Usuário/Email já cadastrado!";

                    return response;
                }

                _senhaInterface.CriarSenhaHash(usuarioCriacaoDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                UsuarioModel usuario = _mapper.Map<UsuarioModel>(usuarioCriacaoDto);

                usuario.SenhaHash = senhaHash;
                usuario.SenhaSalt = senhaSalt;

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                response.Mensagem = "Usuário cadastrado com sucesso!";
                response.Dados = usuario;

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> RemoverUsuario(int id)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                if (usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado!";

                    return response;
                }

                _context.Remove(usuario);
                await _context.SaveChangesAsync();

                response.Dados = usuario;
                response.Mensagem = $"Usuário {usuario.Nome} removido com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        private bool VerificaExistenciaEmailUsuario (UsuarioCriacaoDto usuarioCriacaoDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(i => i.Email == usuarioCriacaoDto.Email ||
                                                                i.Usuario == usuarioCriacaoDto.Usuario);

            if(usuario != null)
            {
                return false;
            }

            return true;
        }
    }
}
