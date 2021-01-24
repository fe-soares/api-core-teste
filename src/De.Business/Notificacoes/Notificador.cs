using De.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace De.Business.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacao;

        public Notificador()
        {
            _notificacao = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacao.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacao;
        }

        public bool TemNoticacao()
        {
            return _notificacao.Any();
        }
    }
}
