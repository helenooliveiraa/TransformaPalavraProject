using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Transforma.Domain.Commands;
using Transforma.Domain.Core;
using Transforma.Domain.Factory;
using Transforma.Domain.Interfaces;

namespace Transforma.Domain.CommandHandler
{
    public class TransformarPalavraCommandHandler : IRequestHandler<TransformarPalavraCommand, CommandResult>
    {
        private readonly ITransformaPalavraRepository _repository;

        public TransformarPalavraCommandHandler(ITransformaPalavraRepository repository)
        {
            _repository = repository;
        }

        public Task<CommandResult> Handle(TransformarPalavraCommand request, CancellationToken cancellationToken)
        {
            var domain = TransformaPalavraFactory.Create(request);

            _repository.Add(domain);

            return Task.FromResult(new CommandResult(domain.TotalMovimentacao));
        }
    }
}
