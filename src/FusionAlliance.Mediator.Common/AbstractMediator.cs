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
    public abstract class AbstractMediator : IMediator, IRequestHandlerInstanceResolver
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
            if (request == null) throw new ArgumentNullException("request");
            var requestHandlerInfo = new RequestHandlerMethodResolver(this).GetHandlerMethod(request);
            return InvokeHandlerMethod<TReply>(requestHandlerInfo, request);
        }

        public abstract object GetInstanceOfHandler(Type type);

        protected virtual TReply InvokeHandlerMethod<TReply>(RequestHandlerInfo handlerInfo, params object[] parameters)
        {
            if (handlerInfo == null) throw new ArgumentNullException("handlerInfo");

            var result = handlerInfo.Method.Invoke(handlerInfo.HandlerInstance, parameters);
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
