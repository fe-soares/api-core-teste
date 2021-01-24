using De.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace De.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNoticacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}
