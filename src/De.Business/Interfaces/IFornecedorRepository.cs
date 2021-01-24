using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using De.Business.Models;

namespace De.Business.Interfaces
{
    public interface IFornecedorRepository : IRepositoryBase<Fornecedor>
    {
        Task<Fornecedor> ObterEnderecoFornecedor(Guid id);

        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}
