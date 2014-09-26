namespace FusionAlliance.Mediator.Common.Tests
{
    public class SquareInteger : IRequest<SquareIntegerReply>
    {
        private readonly int _value;

        public SquareInteger(int value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return string.Format("Value: {0}", _value);
        }

        public int Value
        {
            get { return _value; }
        }
    }
}
