namespace FusionAlliance.Mediator.Common
{
    /// <summary>
    /// Base implementation of a request handler. Request handlers in your application should
    /// inherit from this class, providing a custom implementation of the Handle method.
    /// 
    /// If private fields need to be disposed, override the OnDisposing method.
    /// 
    /// This class is abstract.
    /// </summary>
    /// <typeparam name="TRequest">Type of request for this handler.</typeparam>
    /// <typeparam name="TReply">Type of reply.</typeparam>
    public abstract class AbstractRequestHandler<TRequest, TReply> : IRequestHandler<TRequest, TReply>
        where TRequest : IRequest<TReply>
    {
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
        }

        public abstract TReply Handle(TRequest request);

        protected virtual void OnDisposing() { }

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
