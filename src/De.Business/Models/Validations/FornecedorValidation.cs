﻿using De.Business.Models.Validations.Documentos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace De.Business.Models.Validations
{
    public class FornecedorValidation: AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2,100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
            {
                RuleFor(f => f.Documeto.Length).Equal(CpfValidacao.TamanhoCpf).WithMessage("O campo documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(f => CpfValidacao.Validar(f.Documeto)).Equal(true).WithMessage("O documento fornecido é invalido");
            });

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(f => f.Documeto.Length).Equal(CnpjValidacao.TamanhoCnpj).WithMessage("O campo documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(f => CnpjValidacao.Validar(f.Documeto)).Equal(true).WithMessage("O documento fornecido é invalido");
            });
        }
    }
}
