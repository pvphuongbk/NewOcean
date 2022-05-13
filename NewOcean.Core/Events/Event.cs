using MediatR;

namespace NewOcean.Core.Events
{
    public abstract class Event : Message, INotification
    {
    }
}
