using System;

namespace FusionAlliance.Mediator.Common
{
    public interface IRequestHandlerInstanceResolver
    {
        object GetInstanceOfHandler(Type handlerType);
    }
}
