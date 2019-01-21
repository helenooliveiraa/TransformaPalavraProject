using FluentValidation;
using Transforma.Domain.Commands;

namespace Transforma.Domain.Validators
{
    public class TransformaPalavraCommandValidator : AbstractValidator<TransformarPalavraCommand>
    {
        public TransformaPalavraCommandValidator()
        {
            RuleFor(x => x.PrimeiraPalavra)
                .NotNull()
                .NotEmpty()
                .WithMessage("A primeira palavra deve ser informada.");

            RuleFor(x => x.SegundaPalavra)
                .NotNull()
                .NotEmpty()
                .WithMessage("A segunda palavra deve ser informada.");
        }
    }
}
