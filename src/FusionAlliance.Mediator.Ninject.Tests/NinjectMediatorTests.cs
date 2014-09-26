using System;
using FusionAlliance.Mediator.Common;
using FusionAlliance.Mediator.Common.Tests;
using Ninject;
using NUnit.Framework;

namespace FusionAlliance.Mediator.Ninject.Tests
{
    [TestFixture]
    public class NinjectMediatorTests : IDisposable
    {
        private IKernel _kernel;
        private IMediator _mediator;

        [SetUp]
        public void BeforeEachTest()
        {
            SetUpKernel();
            SetUpMediator();
        }

        [TearDown]
        public void AfterEachTest()
        {
            Dispose();
        }

        [Test]
        public void It_can_double_an_integer()
        {
            var doubleInteger = new DoubleInteger(5);
            var reply = _mediator.Request(doubleInteger);
            Assert.AreEqual(10, reply.DoubledValue);
        }

        [Test]
        public void It_throws_an_exception_when_the_handler_cannot_be_resolved()
        {
            var squareInteger = new SquareInteger(5);
            Assert.Throws<UnableToResolveRequestException>(() => _mediator.Request(squareInteger));
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _kernel.Dispose();
                _mediator.Dispose();
            }
        }

        private void SetUpKernel()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IRequestHandler<DoubleInteger, DoubleIntegerReply>>().To<DoubleIntegerHandler>();
        }

        private void SetUpMediator()
        {
            _mediator = new NinjectMediator(_kernel);
        }
    }
}
