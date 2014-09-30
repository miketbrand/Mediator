using System.Threading.Tasks;

namespace FusionAlliance.Mediator.Common
{
    public abstract class AbstractAsyncRequestHandler<TRequest, TReply> : IAsyncRequestHandler<TRequest, TReply>
        where TRequest : IRequest<TReply>
    {
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
        }

        public abstract Task<TReply> Handle(TRequest request);

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
