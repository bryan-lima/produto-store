using FluentValidation;
using FluentValidation.Results;
using ProdutoStore.Business.Interfaces.Notificacoes;
using ProdutoStore.Business.Models;
using ProdutoStore.Business.Notificacoes;

namespace ProdutoStore.Business.Services
{
    public abstract class BaseService
    {
        #region Campos Privados

        private readonly INotificador _notificador;

        #endregion Campos Privados

        #region Construtores Protegidos

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        #endregion Construtores Protegidos

        #region Métodos Protegidos

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (ValidationFailure erro in validationResult.Errors)
                Notificar(erro.ErrorMessage);
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            ValidationResult _validationResult = validacao.Validate(entidade);

            return _validationResult.IsValid;
        }

        #endregion Métodos Protegidos
    }
}
