namespace FusionAlliance.Mediator.Common.Tests
{
    public class SayHello : IRequest<SayHelloReply>
    {
        public SayHello(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
