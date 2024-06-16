using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Entities
{
    public sealed class Tipo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
    }
}
