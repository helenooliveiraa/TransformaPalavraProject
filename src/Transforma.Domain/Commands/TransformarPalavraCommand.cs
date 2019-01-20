using MediatR;
using Transforma.Domain.Core;
using Transforma.Domain.Validators;

namespace Transforma.Domain.Commands
{
    public class TransformarPalavraCommand : Command
    {
        public string PrimeiraPalavra { get; set; }
        public string SegundaPalavra { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new TransformaPalavraCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
