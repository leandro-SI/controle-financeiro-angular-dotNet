using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Dtos
{
    public class CategoriaDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }Interfaces
        public long TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public ICollection<Despesa> Despesas { get; set; }
        public ICollection<Ganho> Ganhos { get; set; }
    }
}
