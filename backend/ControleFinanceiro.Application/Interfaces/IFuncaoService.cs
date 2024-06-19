using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Interfaces
{
    public interface IFuncaoService
    {
        Task<FuncaoDTO> GetById(string id);
        Task Adicionar(FuncaoDTO funcao);
        Task Atualizar(FuncaoDTO funcao);
    }
}
