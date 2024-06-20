﻿using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Dtos
{
    public class UsuarioDTO
    {
        public string CPF { get; set; }
        public string Profissao { get; set; }
        public byte[] Foto { get; set; }

    }
}
