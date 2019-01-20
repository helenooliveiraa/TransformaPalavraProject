using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Transforma.Domain.Core
{
    public class CommandResult
    {
        private readonly IList<string> _messages = new List<string>();

        public IEnumerable<string> Errors { get; }
        public object Result { get; }

        public CommandResult() => Errors = new ReadOnlyCollection<string>(_messages);

        public CommandResult(object result) : this() => Result = result;

        public CommandResult AddError(string message)
        {
            _messages.Add(message);
            return this;
        }
    }
}
