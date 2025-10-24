using AutoMapper;
using WebApiUsuarios.Dto.Usuario;
using WebApiUsuarios.Models;

namespace WebApiUsuarios.Profiles
{
    public class ProfilesAutoMapper : Profile
    {
        public ProfilesAutoMapper()
        {
            CreateMap<UsuarioCriacaoDto, UsuarioModel>().ReverseMap();
        }
    }
}
