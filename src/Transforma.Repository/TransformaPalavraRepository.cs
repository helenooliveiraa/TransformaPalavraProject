using System.Collections.Generic;
using Transforma.Domain.Interfaces;
using Transforma.Domain.Models;

namespace Transforma.Repository
{
    public class TransformaPalavraRepository : ITransformaPalavraRepository
    {
        private static List<TransformaPalavra> TransformaPalavraList { get; set; }

        public TransformaPalavraRepository()
        {
            TransformaPalavraList = new List<TransformaPalavra>();
        }

        public void Add(TransformaPalavra domain)
        {
            TransformaPalavraList.Add(domain);
        }
    }
}
