using System;
using FusionAlliance.Mediator.Common;
using FusionAlliance.Mediator.Common.Tests;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace FusionAlliance.Mediator.Unity.Tests
{
    [TestFixture]
    public class UnityMediatorTests : IDisposable
    {
        private UnityContainer _container;
        private UnityMediator _mediator;

        [SetUp]
        public void BeforeEachTest()
        {
            _container = new UnityContainer();
            _container.RegisterType<IRequestHandler<DoubleInteger, DoubleIntegerReply>, DoubleIntegerHandler>();
            _mediator = new UnityMediator(_container);
        }

        [Test]
        public void It_can_resolve_a_request()
        {
            var doubleInteger = new DoubleInteger(6);
            var reply = _mediator.Request(doubleInteger);
            Assert.AreEqual(12, reply.DoubledValue);
        }

        [Test]
        public void It_throws_an_exception_when_the_container_is_null()
        {
            IUnityContainer container = null;
            Assert.Throws<ArgumentNullException>(() => new UnityMediator(container));
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _container.Dispose();
                _mediator.Dispose();
            }
        }
    }
}
