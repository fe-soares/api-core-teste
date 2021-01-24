using System;
using System.Collections.Generic;
using System.Text;

namespace De.Business.Models
{
    public class Fornecedor: Entity
    {
        public string Nome { get; set; }

        public string Documeto { get; set; }

        public TipoFornecedor TipoFornecedor { get; set; }

        public bool Ativo { get; set; }

        /* Ef Relations*/
        public Endereco Endereco { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
