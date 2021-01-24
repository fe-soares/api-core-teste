using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using De.Business.Models;

namespace De.Business.Interfaces
{
    public interface IEnderecoRepository : IRepositoryBase<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
