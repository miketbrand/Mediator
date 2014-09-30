namespace FusionAlliance.Mediator.Common.Tests
{
    public class DoubleIntegerHandler : AbstractRequestHandler<DoubleInteger, DoubleIntegerReply>
    {
        public override DoubleIntegerReply Handle(DoubleInteger request)
        {
            var doubledValue = request.Value*2;
            return new DoubleIntegerReply(doubledValue);
        }
    }
}