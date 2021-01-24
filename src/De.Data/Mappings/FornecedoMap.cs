using De.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace De.Data.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(200)");

            builder.Property(p => p.Documeto).IsRequired().HasColumnType("varchar(14)");

            // 1 : 1 => Fornecedor : endereco
            builder.HasOne(f => f.Endereco).WithOne(e => e.Fornecedor).HasForeignKey<Endereco>(f => f.FornedorId);

            // 1 : N => Fornecedor : Produtos
            builder.HasMany(f => f.Produtos).WithOne(p => p.Fornecedor).HasForeignKey(p => p.FornecedorId);

            builder.Property(p => p.TipoFornecedor).HasColumnType("Integer(1)");

            builder.ToTable("Fornecedores");
        }
    }
}