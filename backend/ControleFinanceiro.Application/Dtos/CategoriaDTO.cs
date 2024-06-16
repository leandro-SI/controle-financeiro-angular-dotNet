using ControleFinanceiro.Domain.Entities;
using System.Text.Json.Serialization;

namespace ControleFinanceiro.Application.Dtos
{
    public class CategoriaDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }
        public long TipoId { get; set; }
        [JsonIgnore]
        public Tipo Tipo { get; set; }

    }
}
