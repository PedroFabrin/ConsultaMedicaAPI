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
    public class ConsultaService : IConsultaService
    {
        private IConsultaRepositorio repositorio;
        private IMapper mapper;

        public ConsultaService(IConsultaRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        public async Task<ConsultaDTO> addAsync(ConsultaDTO consultaDto)
        {
            var cons = mapper.Map<Consulta>(consultaDto);
            cons = await this.repositorio.addAsync(cons);
            return mapper.Map<ConsultaDTO>(cons);
        }

        public async Task<IEnumerable<ConsultaDTO>> getAllAsync(Expression<Func<Consulta, bool>> expression)
        {
            var listacons = await this.repositorio.getAllAsync(expression);
            return mapper.Map<IEnumerable<ConsultaDTO>>(listacons);
        }

        public async Task<ConsultaDTO?> getAsync(int id)
        {
            var consId = await this.repositorio.getAsync(id);
            return mapper.Map<ConsultaDTO>(consId);
        }

        public async Task removeAsync(int id)
        {
            var cons = await this.repositorio.getAsync(id);
            if (cons != null)
                await this.repositorio.removeAsync(cons);
        }

        public async Task updateAsync(ConsultaDTO consultaDto)
        {
            var cons = mapper.Map<Consulta>(consultaDto);
            await this.repositorio.updateAsync(cons);
        }
    }
}
