using De.Business.Interfaces;
using De.Business.Models;
using De.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace De.Business.Service
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository ,INotificador noficador) : base(noficador)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Add(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Update(produto);
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepository.Delete(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
