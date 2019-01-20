using FluentValidation.Results;
using MediatR;
using System;

namespace Transforma.Domain.Core
{
    public abstract class Command : IRequest<CommandResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
