using ControleFinanceiro.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Interfaces
{
    public interface IMesService
    {
        Task<IEnumerable<MesDTO>> GetAll();
    }
}
