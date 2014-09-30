namespace FusionAlliance.Mediator.Common.Tests
{
    public class SayHelloReply
    {
        public SayHelloReply(string hello)
        {
            Hello = hello;
        }

        public string Hello { get; private set; }
    }
}
