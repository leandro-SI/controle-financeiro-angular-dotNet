using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infra.Data.EntitiesMapeamentos
{
    public class MesMap : IEntityTypeConfiguration<Mes>
    {
        public void Configure(EntityTypeBuilder<Mes> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(10);
            builder.HasIndex(m => m.Nome)
                .IsUnique();             

            builder.HasMany(m => m.Ganhos).WithOne(m => m.Mes);
            builder.HasMany(m => m.Despesas).WithOne(m => m.Mes);

            builder.HasData(
                new Mes { Id = 1, Nome = "Janeiro"},
                new Mes { Id = 2, Nome = "Fevereiro"},
                new Mes { Id = 3, Nome = "Março"},
                new Mes { Id = 4, Nome = "Abril"},
                new Mes { Id = 5, Nome = "Maio"},
                new Mes { Id = 6, Nome = "Junho"},
                new Mes { Id = 7, Nome = "Julho"},
                new Mes { Id = 8, Nome = "Agosto"},
                new Mes { Id = 9, Nome = "Setembro"},
                new Mes { Id = 10, Nome = "Outubro"},
                new Mes { Id = 11, Nome = "Novembro"},
                new Mes { Id = 12, Nome = "Dezembro"}
            );

            builder.ToTable("Meses");
        }
    }
}
