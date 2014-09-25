namespace FusionAlliance.Mediator.Common.Tests
{
    public class DoubleIntegerReply
    {
        private readonly int _doubledValue;

        public DoubleIntegerReply(int doubledValue)
        {
            _doubledValue = doubledValue;
        }

        public int DoubledValue
        {
            get { return _doubledValue; }
        }
    }
}
