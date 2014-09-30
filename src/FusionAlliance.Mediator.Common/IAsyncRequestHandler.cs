using System;
using System.Threading.Tasks;

namespace FusionAlliance.Mediator.Common
{
    public interface IAsyncRequestHandler<in TRequest, TReply> : IDisposable
        where TRequest : IRequest<TReply>
    {
        bool IsDisposed { get; }

        Task<TReply> Handle(TRequest request);
    }
}
