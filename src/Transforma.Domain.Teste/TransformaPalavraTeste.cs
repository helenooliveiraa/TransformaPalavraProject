using System;
using Transforma.Domain.Commands;
using Transforma.Domain.Factory;
using Xunit;

namespace Transforma.Domain.Teste
{
    public class TransformaPalavraTeste
    {
        [Fact]
        public void TransformarPalavra1()
        {
            var domain = TransformaPalavraFactory.Create(new TransformarPalavraCommand
            {
                PrimeiraPalavra = "Gato",
                SegundaPalavra = "Rato"
            });

            Assert.Equal(1, domain.TotalMovimentacao);
        }

        [Fact]
        public void TransformarPalavra2()
        {
            var domain = TransformaPalavraFactory.Create(new TransformarPalavraCommand
            {
                PrimeiraPalavra = "Cavalo",
                SegundaPalavra = "Pato"
            });

            Assert.Equal(4, domain.TotalMovimentacao);
        }

        [Fact]
        public void TransformarPalavra3()
        {
            var domain = TransformaPalavraFactory.Create(new TransformarPalavraCommand
            {
                PrimeiraPalavra = "Foca",
                SegundaPalavra = "Galo"
            });

            Assert.Equal(4, domain.TotalMovimentacao);
        }

        [Fact]
        public void TransformarPalavra4()
        {
            var domain = TransformaPalavraFactory.Create(new TransformarPalavraCommand
            {
                PrimeiraPalavra = "Jaca",
                SegundaPalavra = "Carro"
            });

            Assert.Equal(4, domain.TotalMovimentacao);
        }
    }
}
