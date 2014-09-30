using System;
using System.Threading;

namespace FusionAlliance.Mediator.Common.Tests
{
    public class SayHelloHandler : AbstractRequestHandler<SayHello, SayHelloReply>
    {
        public override SayHelloReply Handle(SayHello request)
        {
            var sleepDuration = new Random().Next(100, 500);
            Thread.Sleep(TimeSpan.FromMilliseconds(sleepDuration));
            var hello = string.Format("Hello, {0}!", request.Name);
            return new SayHelloReply(hello);
        }
    }
}
