using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using De.Data.Context;
using De.Data.Repository;
using De.Business.Interfaces;
using De.Business.Notificacoes;
using De.Business.Service;

namespace De.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependecies(this IServiceCollection service)
        {
            service.AddScoped<EfContext>();
            service.AddScoped<IFornecedorRepository, FornecedorRepository>();
            service.AddScoped<IEnderecoRepository, EnderecoRepository>();
            service.AddScoped<IProdutoRepository, ProdutoRepository>();

            service.AddScoped<INotificador, Notificador>();
            service.AddScoped<IFornecedorService, FornecedorService>();
            service.AddScoped<IProdutoService, ProdutoService>();

            return service;
        }
    }
}
