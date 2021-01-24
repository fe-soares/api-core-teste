using De.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Numerics;

namespace De.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao).IsRequired().HasColumnType("varchar(1000)");

            builder.Property(p => p.Imagem).IsRequired().HasColumnType("varchar(100)");

            builder.Property(p => p.Valor).IsRequired().HasColumnType("DECIMAL(4,2)");

            builder.ToTable("Produtos");
        }
    }
}
