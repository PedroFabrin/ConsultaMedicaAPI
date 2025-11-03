using AutoMapper;
using Dominio.Dtos;
using Dominio.Entidades;

namespace ConsultaMedica.mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Usuário
            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(dest => dest.consultas, opt => opt.Ignore());
            CreateMap<Usuario, UsuarioDTO>();

            // Médico
            CreateMap<Medico, MedicoDTO>().ReverseMap();

            // Consulta (aqui é o essencial)
            CreateMap<Consulta, ConsultaDTO>()
                .ForMember(dest => dest.Medico, opt => opt.MapFrom(src => src.medico))
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.usuario))
                .ReverseMap();

            // Secretaria
            CreateMap<Secretaria, SecretariaDTO>().ReverseMap();
        }
    }
}
