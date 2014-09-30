namespace FusionAlliance.Mediator.Common
{
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
