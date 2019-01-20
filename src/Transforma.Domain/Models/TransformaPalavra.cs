using System.Linq;

namespace Transforma.Domain.Models
{
    public class TransformaPalavra
    {
        public TransformaPalavra(string primeiraPalavra, string segundaPalavra)
        {
            PrimeiraPalavra = primeiraPalavra;
            SegundaPalavra = segundaPalavra;

            CalcularTotalMovimentacoes();
        }

        public string PrimeiraPalavra { get; private set; }
        public string SegundaPalavra { get; private set; }
        public int TotalMovimentacao { get; private set; }

        public void CalcularTotalMovimentacoes()
        {
            int qtdLetraRemovida = ObterQuantidadeLetraRemovida();

            TotalMovimentacao = qtdLetraRemovida +
                ObterQuantidadeAlteracoes(RemoverLetrasPrimeiraPalavra(qtdLetraRemovida),
                                          RemoverLetrasSegundaPalavra(qtdLetraRemovida));
        }

        private int ObterQuantidadeLetraRemovida()
        {
            int qtd = PrimeiraPalavra.Length - SegundaPalavra.Length;

            if (qtd <= 0)
                qtd = qtd * -1;

            return qtd;
        }

        private string RemoverLetrasPrimeiraPalavra(int qtdLetraRemovida)
        {
            if (PrimeiraPalavra.Length > SegundaPalavra.Length)
                return PrimeiraPalavra.Substring(qtdLetraRemovida, PrimeiraPalavra.Length - qtdLetraRemovida);

            return PrimeiraPalavra;
        }

        private string RemoverLetrasSegundaPalavra(int qtdLetraRemovida)
        {
            if (SegundaPalavra.Length > PrimeiraPalavra.Length)
                return SegundaPalavra.Substring(qtdLetraRemovida, SegundaPalavra.Length - qtdLetraRemovida);

            return SegundaPalavra;
        }

        private int ObterQuantidadeAlteracoes(string primeiraPalavra, string segundaPalavra)
        {
            int qtdAlteracao = 0;

            var primeiraPalavraList = primeiraPalavra.ToCharArray();
            var segundaPalavraList = segundaPalavra.ToCharArray();

            for (int i = 0; i < primeiraPalavraList.Length; i++)
            {
                if (primeiraPalavraList[i] != segundaPalavraList[i])
                    qtdAlteracao++;
            }

            return qtdAlteracao;
        }
    }
}
