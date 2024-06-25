using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Usuario user, string funcao);
    }
}
