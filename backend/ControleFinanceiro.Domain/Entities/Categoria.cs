using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Entities
{
    public sealed class Categoria
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }
        public long TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public ICollection<Despesa> Despesas { get; set; }
        public ICollection<Ganho> Ganhos { get; set; }
    }
}
