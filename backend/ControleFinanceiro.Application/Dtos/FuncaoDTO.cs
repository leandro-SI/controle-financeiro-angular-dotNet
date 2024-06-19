using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Dtos
{
    public class FuncaoDTO : IdentityRole<string>
    {
        public string Descricao { get; set; }
    }
}
