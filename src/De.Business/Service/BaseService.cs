using De.Business.Interfaces;
using De.Business.Models;
using De.Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace De.Business.Service
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador noficador)
        {
            _notificador = noficador;
        }
        protected void Notificar(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);
            return false;
        }
    }
}
