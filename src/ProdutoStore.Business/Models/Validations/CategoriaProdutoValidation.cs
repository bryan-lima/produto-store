using FluentValidation;

namespace ProdutoStore.Business.Models.Validations
{
    public class CategoriaProdutoValidation : AbstractValidator<CategoriaProduto>
    {
        public CategoriaProdutoValidation()
        {
            RuleFor(categoriaProduto => categoriaProduto.Nome)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 250)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(categoriaProduto => categoriaProduto.Descricao)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 250)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
