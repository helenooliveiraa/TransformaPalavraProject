using System;
using System.Linq;

namespace Transforma.Domain.Models
{
    public class TransformaPalavra
    {
        public TransformaPalavra(string primeiraPalavra, string segundaPalavra)
        {
            PrimeiraPalavra = primeiraPalavra;
            SegundaPalavra = segundaPalavra;

            TotalMovimentacao = ObterTotalMovimentacoes();
        }

        public string PrimeiraPalavra { get; private set; }
        public string SegundaPalavra { get; private set; }
        public int TotalMovimentacao { get; private set; }

        public int ObterTotalMovimentacoes()
        {
            int qtdLetraAlterada = ObterQuantidadeLetraAlterada();

            string primeiraPalavra = PrimeiraPalavra;
            string segundaPalavra = SegundaPalavra;

            if (qtdLetraAlterada > 0)
                primeiraPalavra = PrimeiraPalavra.Substring(qtdLetraAlterada, PrimeiraPalavra.Length - qtdLetraAlterada);

            return qtdLetraAlterada + ObterQuantidadeAlteracoes(primeiraPalavra, segundaPalavra);
        }

        private int ObterQuantidadeLetraAlterada()
        {
            int qtd = PrimeiraPalavra.Length - SegundaPalavra.Length;

            if (qtd <= 0)
                return 0;

            return qtd;
        }

        private int ObterQuantidadeAlteracoes(string primeiraPalavra, string segundaPalavra)
        {
            try
            {
                int qtdAlteracao = 0;

                var primeiraPalavraList = primeiraPalavra.ToCharArray();
                var segundaPalavraList = segundaPalavra.ToCharArray();

                for (int i = 0; i < segundaPalavraList.Length; i++)
                {
                    if (primeiraPalavraList.Count() < (i + 1))
                    {
                        qtdAlteracao++;
                        continue;
                    }

                    if (primeiraPalavraList[i].ToString().ToLower() != segundaPalavraList[i].ToString().ToLower())
                        qtdAlteracao++;
                }

                return qtdAlteracao;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
