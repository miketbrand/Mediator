using System;

namespace FusionAlliance.Mediator.Common
{
    public abstract class AbstractMediator : IMediator
    {
        public void Dispose()
        {
            Dispose(true);
        }

        public TReply Request<TReply>(IRequest<TReply> request)
        {
            Type requestType = request.GetType();
            Type replyType = typeof(TReply);
            RequestHandlerInfo handler = GetRequestHandler(typeof(IRequestHandler<,>), requestType, replyType);
            object instance = GetInstanceOfHandler(handler.GenericType);
            return InvokeHandlerMethod<TReply>(handler, instance, request);
        }

        protected abstract void Dispose(bool isDisposing);

        protected virtual RequestHandlerInfo GetRequestHandler(Type requestHandlerType, Type requestType, Type replyType, string methodName = "Handle")
        {
            var genericType = requestHandlerType.MakeGenericType(requestType, replyType);
            var method = genericType.GetMethod(methodName);
            return new RequestHandlerInfo
            {
                GenericType = genericType,
                Method = method
            };
        }

        protected abstract object GetInstanceOfHandler(Type type);

        protected virtual TReply InvokeHandlerMethod<TReply>(RequestHandlerInfo handlerInfo, object instance, params object[] parameters)
        {
            if (handlerInfo == null)
            {
                throw new ArgumentNullException("handlerInfo");
            }
            var result = handlerInfo.Method.Invoke(instance, parameters);
            return (TReply)result;
        }
    }
}
