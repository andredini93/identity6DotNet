using AutoMapper;
using Identity6.Data.DTOs;
using Identity6.Models;

namespace Identity6.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDTO, Usuario>();
        }
    }
}
