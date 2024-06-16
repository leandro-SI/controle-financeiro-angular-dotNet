using Microsoft.AspNetCore.Identity;

namespace ControleFinanceiro.Domain.Entities
{
    public sealed class Funcao : IdentityRole<string>
    {
        public string Descricao { get; set; }
    }
}
