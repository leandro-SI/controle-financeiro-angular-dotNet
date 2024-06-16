using Microsoft.AspNetCore.Identity;

namespace ControleFinanceiro.Domain.Entities
{
    public sealed class Usuario : IdentityUser<string>
    {
        public string CPF { get; set; }
        public string Profissao { get; set; }
        public byte[] Foto { get; set; }
        public ICollection<Cartao> Cartoes { get; set; }
        public ICollection<Ganho> Ganhos { get; set; }
        public ICollection<Despesa> Despesas { get; set; }
    }
}
