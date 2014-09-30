using System;

namespace FusionAlliance.Mediator.Common
{
    /// <summary>
    /// Interface for a request handler.
    /// </summary>
    /// <typeparam name="TRequest">Type of request to handle</typeparam>
    /// <typeparam name="TReply">Type of reply to send from the request.</typeparam>
    public interface IRequestHandler<in TRequest, out TReply> : IDisposable
        where TRequest : IRequest<TReply>
    {
        bool IsDisposed { get; }

        /// <summary>
        /// Handle the given request.
        /// </summary>
        /// <param name="request">Request to be handled.</param>
        /// <returns>Reply</returns>
        TReply Handle(TRequest request);
    }
}
