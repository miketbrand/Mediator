using System;
using NUnit.Framework;

namespace FusionAlliance.Mediator.Common.Tests
{
    [TestFixture]
    public class SimpleMediatorTests : IDisposable
    {
        private SimpleMediator _mediator;

        [SetUp]
        public void BeforeEachTest()
        {
            _mediator = new SimpleMediator();
            _mediator.Bind(typeof(IRequestHandler<DoubleInteger, DoubleIntegerReply>), typeof(DoubleIntegerHandler));
        }

        [Test]
        public void It_can_resolve_request()
        {
            var doubleInteger = new DoubleInteger(5);
            var reply = _mediator.Request(doubleInteger);
            Assert.AreEqual(10, reply.DoubledValue);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _mediator.Dispose();
            }
        }
    }
}
