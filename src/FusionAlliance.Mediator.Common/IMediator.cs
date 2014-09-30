using System;
using System.Threading.Tasks;

namespace FusionAlliance.Mediator.Common
{
    /// <summary>
    /// Broker interface for managing request/reply responsibilities.
    /// </summary>
    /// <example>
    /// </example>
    public interface IMediator : IDisposable
    {
        bool IsDisposed { get; }

        TReply Request<TReply>(IRequest<TReply> request);

        Task<TReply> RequestAsync<TReply>(IRequest<TReply> request);
    }
}
