using System;

namespace FusionAlliance.Mediator.Common
{
    /// <summary>
    /// Broker interface for managing request/reply responsibilities.
    /// </summary>
    /// <example>
    /// </example>
    public interface IMediator : IDisposable
    {
        TReply Request<TReply>(IRequest<TReply> request);
    }
}
