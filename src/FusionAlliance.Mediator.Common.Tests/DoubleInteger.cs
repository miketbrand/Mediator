namespace FusionAlliance.Mediator.Common.Tests
{
    public class DoubleInteger : IRequest<DoubleIntegerReply>
    {
        private readonly int _value;

        public DoubleInteger(int value)
        {
            _value = value;
        }

        public int Value
        {
            get { return _value; }
        }
    }
}
