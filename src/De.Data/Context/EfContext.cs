using De.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace De.Data.Context
{
    public class EfContext: DbContext
    {
        public EfContext(DbContextOptions<EfContext> options) : base(options) {}
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            //desabilita o delet caskate
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
