using System;

namespace FusionAlliance.Mediator.Common
{
    /// <summary>
    /// Broker interface for managing request/reply responsibilities. The mediator
    /// will take care of finding the appropriate handler and executing the result.
    /// </summary>
    /// <example>
    /// var sayHello = new SayHello("World");
    /// var reply = mediator.Request(sayHello);
    /// </example>
    public interface IMediator : IDisposable
    {
        /// <summary>
        /// Is this mediator disposed?
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// Send a request to the mediator.
        /// </summary>
        /// <typeparam name="TReply">Type of reply returned by the request.</typeparam>
        /// <param name="request">Request to handle.</param>
        /// <returns>Reply.</returns>
        TReply Request<TReply>(IRequest<TReply> request);
    }
}
