using System;

namespace FusionAlliance.Mediator.Common
{
    public interface IMediator : IDisposable
    {
        TReply Request<TReply>(IRequest<TReply> request);
    }
}
