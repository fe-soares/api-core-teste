using AutoMapper;
using De.Business.Models;
using Dev.Api.ViewModels;

namespace De.Api.Configuration
{
    public class AutomapperConfig: Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();//mapeia e fornecedor para forViewModel
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
