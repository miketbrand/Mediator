using System;

namespace FusionAlliance.Mediator.Common
{
    /// <summary>
    /// Base implementation of a mediator. Other mediators will share the
    /// functionality of this class, overriding the GetInstanceOfHandler
    /// method.
    /// 
    /// This class is abstract.
    /// </summary>
    public abstract class AbstractMediator : IMediator
    {
        /// <summary>
        /// Is this mediator disposed?
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Dispose of the mediator.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Send a request to the mediator.
        /// </summary>
        /// <typeparam name="TReply"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public TReply Request<TReply>(IRequest<TReply> request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            Type requestType = request.GetType();
            Type replyType = typeof(TReply);
            RequestHandlerInfo requestHandlerInfo;
            object handlerInstance;
            try
            {
                requestHandlerInfo = GetRequestHandlerInfo(typeof(IRequestHandler<,>), requestType, replyType);
                handlerInstance = GetInstanceOfHandler(requestHandlerInfo.GenericType);
            }
            catch (Exception e)
            {
                var message = string.Format("Unable to resolve request.\nRequested type: {0}\nRequest: {1}", typeof(IRequest<TReply>), request);
                throw new UnableToResolveRequestException(message, e);
            }
            return InvokeHandlerMethod<TReply>(requestHandlerInfo, handlerInstance, request);
        }

        protected virtual RequestHandlerInfo GetRequestHandlerInfo(Type requestHandlerType, Type requestType, Type replyType, string methodName = "Handle")
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
            if (handlerInfo == null) throw new ArgumentNullException("handlerInfo");
            if (instance == null) throw new ArgumentNullException("instance");

            var result = handlerInfo.Method.Invoke(instance, parameters);
            return (TReply)result;
        }

        protected virtual void OnDisposing()
        {
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                OnDisposing();
                IsDisposed = true;
            }
        }
    }
}
