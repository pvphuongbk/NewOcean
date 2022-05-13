using NewOcean.Core.Base;
using MediatR;

namespace NewOcean.Core.Commands
{
    public interface ICommand<TResult> : IRequest<TResult>
    {

    }
}
