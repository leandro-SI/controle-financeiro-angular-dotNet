using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infra.Data.EntitiesMapeamentos
{
    public class TipoMap : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasMany(t => t.Categorias).WithOne(t => t.Tipo);

            builder.HasData(
                new Tipo { Id = 1, Nome = "Despesa"},
                new Tipo { Id = 2, Nome = "Ganho" }
            );

            builder.ToTable("Tipos");
        }
    }
}
