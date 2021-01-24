using System;
using System.Collections.Generic;
using System.Text;

namespace De.Business.Models
{
    public class Produto: Entity
    {
        public Guid FornecedorId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        /*EF relations*/

        public Fornecedor Fornecedor { get; set; }
    }
}
