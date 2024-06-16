using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infra.Data.EntitiesMapeamentos
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Icone)
                .IsRequired();

            builder.HasOne(c => c.Tipo)
                .WithMany(c => c.Categorias)
                .HasForeignKey(c => c.TipoId)
                .IsRequired();

            builder.HasMany(c => c.Ganhos)
                .WithOne(c => c.Categoria);

            builder.HasMany(c => c.Despesas)
                .WithOne(c => c.Categoria);

            builder.ToTable("Categorias");
        }
    }
}
