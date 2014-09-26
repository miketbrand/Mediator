namespace FusionAlliance.Mediator.Common.Tests
{
    public class SquareIntegerReply
    {
        private readonly int _squaredValue;

        public SquareIntegerReply(int squaredValue)
        {
            _squaredValue = squaredValue;
        }

        public int SquaredValue
        {
            get { return _squaredValue; }
        }
    }
}
