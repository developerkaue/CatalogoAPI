using CatalogoAPI.Models;
using FluentValidation;

namespace CatalogoAPI.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome).MinimumLength(3).WithMessage("O nome do produto deve ter no mínimo 3 caracteres.");
            RuleFor(p => p.Preco).GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
            RuleFor(p => p.Estoque).GreaterThanOrEqualTo(0).WithMessage("O estoque deve ser um número inteiro positivo.");
            RuleFor(p => p.CategoriaId).GreaterThan(0).WithMessage("O ID da categoria é obrigatório.");
        }
    }
}
