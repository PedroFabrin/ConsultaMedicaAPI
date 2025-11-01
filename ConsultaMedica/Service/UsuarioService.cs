using AutoMapper;
using Dominio.Dtos;
using Dominio.Entidades;
using Interface.Repositorio;
using Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepositorio repositorio;
        private IMapper mapper;

        public UsuarioService(IUsuarioRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        public async Task<UsuarioDTO> addAsync(UsuarioDTO usuarioDto)
        {
            var usu = mapper.Map<Usuario>(usuarioDto);
            usu = await this.repositorio.addAsync(usu);
            return mapper.Map<UsuarioDTO>(usu);
        }

        public async Task<IEnumerable<UsuarioDTO>> getAllAsync(Expression<Func<Usuario, bool>> expression)
        {
            var listausu = await this.repositorio.getAllAsync(expression);
            return mapper.Map<IEnumerable<UsuarioDTO>>(listausu);
        }

        public async Task<UsuarioDTO?> getAsync(int id)
        {
            var usuId = await this.repositorio.getAsync(id);
            return mapper.Map<UsuarioDTO>(usuId);
        }

        public async Task removeAsync(int id)
        {
            var usu = await this.repositorio.getAsync(id);
            if (usu != null)
                await this.repositorio.removeAsync(usu);
        }

        public async Task updateAsync(UsuarioDTO usuarioDto)
        {
            var usu = mapper.Map<Usuario>(usuarioDto);
            await this.repositorio.updateAsync(usu);
        }
    }
}
