using De.Business.Models;
using De.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using De.Data.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace De.Data.Repository
{
    public class FornecedorRepository: RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(EfContext context) : base(context) { }

        public async Task<Fornecedor> ObterEnderecoFornecedor(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking().Include(c => c.Endereco).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking().
                Include(c => c.Produtos).
                Include(c => c.Endereco).
                FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
