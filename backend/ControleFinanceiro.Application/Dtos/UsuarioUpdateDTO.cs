using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Dtos
{
    public class UsuarioUpdateDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }
        public byte[] Foto { get; set; }
    }
}
