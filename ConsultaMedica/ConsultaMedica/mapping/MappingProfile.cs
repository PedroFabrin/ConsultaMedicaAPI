using AutoMapper;
using Dominio.Dtos;
using Dominio.Entidades;

namespace ConsultaMedica.mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Medico, MedicoDTO>().ReverseMap();
            CreateMap<Consulta, ConsultaDTO>().ReverseMap();
            CreateMap<Secretaria, SecretariaDTO>().ReverseMap();
        }
        
    }
}
