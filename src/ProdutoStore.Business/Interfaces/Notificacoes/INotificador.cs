using ProdutoStore.Business.Notificacoes;
using System.Collections.Generic;

namespace ProdutoStore.Business.Interfaces.Notificacoes
{
    public interface INotificador
    {
        #region Métodos Públicos

        bool TemNotificacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);

        #endregion Métodos Públicos
    }
}
