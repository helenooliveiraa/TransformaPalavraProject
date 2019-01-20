using Transforma.Domain.Commands;
using Transforma.Domain.Models;

namespace Transforma.Domain.Factory
{
    public static class TransformaPalavraFactory
    {
        public static TransformaPalavra Create(TransformarPalavraCommand command)
        {
            return new TransformaPalavra(command.PrimeiraPalavra, command.SegundaPalavra);
        }
    }
}
