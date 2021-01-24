using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace De.Business.Models
{
    public class Endereco: Entity
    {
        public Guid FornedorId { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        /*EF relations*/

        public Fornecedor Fornecedor { get; set; }
    }
}
