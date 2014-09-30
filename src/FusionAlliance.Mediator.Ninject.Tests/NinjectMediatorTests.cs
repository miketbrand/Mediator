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
        private static TimeSpan waitDuration = TimeSpan.FromSeconds(5);
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
        public void Disposing_of_the_mediator_does_not_dispose_of_the_kernel()
        {
            _mediator.Dispose();
            Assert.IsTrue(_mediator.IsDisposed);
            Assert.IsFalse(_kernel.IsDisposed);
        }

        [Test]
        public void It_can_double_an_integer()
        {
            var doubleInteger = new DoubleInteger(5);
            var reply = _mediator.Request(doubleInteger);
            Assert.AreEqual(10, reply.DoubledValue);
        }

        [Test]
        public void It_can_say_hello()
        {
            var sayHello = new SayHello("World");
            var reply = _mediator.Request(sayHello);
            Assert.AreEqual("Hello, World!", reply.Hello);
        }

        [Test]
        public void It_can_say_hello_asynchronously()
        {
            var sayHello = new SayHello("World");
            var reply = _mediator.RequestAsync(sayHello);
            reply.Wait(waitDuration);
            Assert.AreEqual("Hello, World!", reply.Result.Hello);
        }

        [Test]
        public void Is_is_disposed_after_calling_Dispose()
        {
            _mediator.Dispose();
            Assert.IsTrue(_mediator.IsDisposed);
        }

        [Test]
        public void Is_is_not_disposed_by_default()
        {
            Assert.IsFalse(_mediator.IsDisposed);
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
            _kernel.Bind<IRequestHandler<SayHello, SayHelloReply>>().To<SayHelloHandler>();
        }

        private void SetUpMediator()
        {
            _mediator = new NinjectMediator(_kernel);
        }
    }
}
