namespace FusionAlliance.Mediator.Common.Tests
{
    public class DoubleIntegerHandler : IRequestHandler<DoubleInteger, DoubleIntegerReply>
    {
        public void Dispose()
        {
            Dispose(true);
        }

        public DoubleIntegerReply Handle(DoubleInteger request)
        {
            var doubledValue = request.Value*2;
            return new DoubleIntegerReply(doubledValue);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            /* Nothing to do here. */
        }
    }
}