using De.Business.Interfaces;
using De.Business.Models;
using De.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.Business.Service
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IEnderecoRepository enderecoRepository, INotificador noficador): base(noficador)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }
        public async Task Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor) && !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            if(_fornecedorRepository.Buscar(f => f.Documeto == fornecedor.Documeto).Result.Any())
            {
                Notificar("Ja existe um fornecedor com o documento informado");
                return;
            }

            await _fornecedorRepository.Add(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if(_fornecedorRepository.Buscar(f => f.Documeto == fornecedor.Documeto && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Ja existe um fornecedor com este documento informado");
                return;
            }

            await _fornecedorRepository.Update(fornecedor);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;
        }

        public async Task Remover(Guid id)
        {
            if (_fornecedorRepository.ObterFornecedorProdutosEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastratados");
                return;
            }

            await _fornecedorRepository.Delete(id);
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
