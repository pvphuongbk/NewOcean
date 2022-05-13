using NewOcean.Core.Events;
using FluentValidation.Results;

namespace NewOcean.Core.Commands
{
    public abstract class Command : Message
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}
