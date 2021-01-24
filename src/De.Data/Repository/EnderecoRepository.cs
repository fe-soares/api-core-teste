using System;
using System.Collections.Generic;
using System.Text;
using De.Data.Context;
using De.Business.Models;
using De.Business.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace De.Data.Repository
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(EfContext efContext): base(efContext){}

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking().
                FirstOrDefaultAsync(f => f.FornedorId == fornecedorId);
        }
    }
}
