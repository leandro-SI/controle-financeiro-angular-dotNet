﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Entities
{
    public sealed class Cartao
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Bandeira { get; set; }
        public string Numero { get; set; }
        public decimal Limite { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Despesa> Despesas { get; set; }
    }
}
