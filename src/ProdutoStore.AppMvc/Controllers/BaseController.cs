using ProdutoStore.Business.Interfaces.Notificacoes;
using ProdutoStore.Business.Notificacoes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProdutoStore.AppMvc.Controllers
{
    public class BaseController : Controller
    {
        #region Campos Privados

        private readonly INotificador _notificador;

        #endregion Campos Privados

        #region Construtores Públicos

        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        #endregion Construtores Públicos

        #region Métodos Protegidos

        protected bool OperacaoValida()
        {
            if (!_notificador.TemNotificacao())
                return true;

            List<Notificacao> _notificacoes = _notificador.ObterNotificacoes();
            _notificacoes.ForEach(notificacao => ViewData.ModelState.AddModelError(key: string.Empty,
                                                                                   errorMessage: notificacao.Mensagem));

            return false;
        }

        #endregion Métodos Protegidos
    }
}