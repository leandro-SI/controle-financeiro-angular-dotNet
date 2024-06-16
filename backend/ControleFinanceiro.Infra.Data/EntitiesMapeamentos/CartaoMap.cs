using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infra.Data.EntitiesMapeamentos
{
    public class CartaoMap : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex().IsUnique();

            builder.Property(c => c.Bandeira)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(c => c.Numero).IsUnique();

            builder.Property(c => c.Limite)
                .IsRequired();

            builder.HasOne(c => c.Usuario)
                .WithMany(c => c.Cartoes)
                .HasForeignKey(c => c.UsuarioId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Despesas)
                .WithOne(c => c.Cartao);

            builder.ToTable("Cartoes");


        }
    }
}
