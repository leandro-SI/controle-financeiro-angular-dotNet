using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Entities
{
    public sealed class Ganho
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public long CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Valor { get; set; }
        public int Dia { get; set; }
        public long MesId { get; set; }
        public Mes Mes { get; set; }
        public int Ano { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
