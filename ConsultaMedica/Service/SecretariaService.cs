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
    public class SecretariaService : ISecretariaService
    {
        private ISecretariaRepositorio repositorio;
        private IMapper mapper;

        public SecretariaService(ISecretariaRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        public async Task<SecretariaDTO> addAsync(SecretariaDTO secretariaDTO)
        {
            var sec = mapper.Map<Secretaria>(secretariaDTO);
            sec = await this.repositorio.addAsync(sec);
            return mapper.Map<SecretariaDTO>(sec);
        }

        public async Task<IEnumerable<SecretariaDTO>> getAllAsync(Expression<Func<Secretaria, bool>> expression)
        {
            var listasec = await this.repositorio.getAllAsync(expression);
            return mapper.Map<IEnumerable<SecretariaDTO>>(listasec);
        }

        public async Task<SecretariaDTO?> getAsync(int id)
        {
            var secId = await this.repositorio.getAsync(id);
            return mapper.Map<SecretariaDTO>(secId);
        }

        public async Task removeAsync(int id)
        {
            var sec = await this.repositorio.getAsync(id);
            if (sec != null)
                await this.repositorio.removeAsync(sec);
        }

        public async Task updateAsync(SecretariaDTO secretariaDTO)
        {
            var sec = mapper.Map<Secretaria>(secretariaDTO);
            await this.repositorio.updateAsync(sec);
        }

        public async Task<SecretariaDTO> getSecretaria(string email, string senha)
        {
            var secretaria = await this.repositorio.getSecretaria(p => p.email == email && p.senha == senha);
            return mapper.Map<SecretariaDTO>(secretaria);
        }
    }
}
