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
    public class MedicoService : IMedicoService
    {
        private IMedicoRepositorio repositorio;
        private IMapper mapper;

        public MedicoService(IMedicoRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        public async Task<MedicoDTO> addAsync(MedicoDTO medicoDto)
        {
            var med = mapper.Map<Medico>(medicoDto);
            med = await this.repositorio.addAsync(med);
            return mapper.Map<MedicoDTO>(med);
        }

        public async Task<IEnumerable<MedicoDTO>> getAllAsync(Expression<Func<Medico, bool>> expression)
        {
            var listamed = await this.repositorio.getAllAsync(expression);
            return mapper.Map<IEnumerable<MedicoDTO>>(listamed);
        }

        public async Task<MedicoDTO?> getAsync(int id)
        {
            var medId = await this.repositorio.getAsync(id);
            return mapper.Map<MedicoDTO>(medId);
        }

        public async Task removeAsync(int id)
        {
            var med = await this.repositorio.getAsync(id);
            if (med != null)
                await this.repositorio.removeAsync(med);
        }

        public async Task updateAsync(MedicoDTO medicoDto)
        {
            var med = mapper.Map<Medico>(medicoDto);
            await this.repositorio.updateAsync(med);
        }
    }
}
