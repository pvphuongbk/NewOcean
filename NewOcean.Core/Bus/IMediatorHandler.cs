using NewOcean.Core.Base;
using NewOcean.Core.Commands;
using NewOcean.Core.Events;
using System.Threading.Tasks;

namespace NewOcean.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<TResult> SendCommand<TRequest, TResult>(TRequest command) where TRequest : ICommand<TResult>;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
