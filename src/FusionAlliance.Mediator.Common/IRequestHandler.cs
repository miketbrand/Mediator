using System;

namespace FusionAlliance.Mediator.Common
{
    public interface IRequestHandler<in TRequest, out TReply> : IDisposable
        where TRequest : IRequest<TReply>
    {
        TReply Handle(TRequest request);
    }
}
