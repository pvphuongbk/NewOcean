using NewOcean.Core.Bus;
using NewOcean.Core.Commands;
using NewOcean.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOcean.Core.Handler
{
    public class CommandHandler
    {
        private readonly IMediatorHandler _bus;

        public CommandHandler(IMediatorHandler bus)
        {
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }
    }
}
