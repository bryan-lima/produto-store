using FluentValidation;
using FluentValidation.Results;
using ProdutoStore.Business.Models;

namespace ProdutoStore.Business.Services
{
    public abstract class BaseService
    {
        #region Métodos Protegidos

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            ValidationResult _validationResult = validacao.Validate(entidade);

            return _validationResult.IsValid;
        }

        #endregion Métodos Protegidos
    }
}
