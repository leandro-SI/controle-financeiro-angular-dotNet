﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Interfaces
{
    public interface IGraficoService
    {
        Task<object> GetGanhosAnuaisByUsuarioId(string userId, int ano);
        Task<object> GetDespesasAnuaisByUsuarioId(string userId, int ano);
    }
}
