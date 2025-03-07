using CatalogoAPI.Models;
using FluentValidation;

namespace CatalogoAPI.Validators
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Nome).MinimumLength(3).WithMessage("O nome da categoria deve ter no mínimo 3 caracteres.");
        }
    }
}
