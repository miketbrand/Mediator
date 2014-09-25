using System;
using FusionAlliance.Mediator.Common;
using Ninject;

namespace FusionAlliance.Mediator.Ninject
{
    public class NinjectMediator : AbstractMediator
    {
        private readonly IKernel _kernel;

        public NinjectMediator(IKernel kernel)
        {
            _kernel = kernel;
        }

        protected override void Dispose(bool isDisposing)
        {
            /* Do not dispose of the kernel. In most applications, the kernel will
             * be a singleton. Disposing of the kernel within the application
             * context is always a bad idea, since it will cause all of the type
             * bindings to be released.
             */
        }

        protected override object GetInstanceOfHandler(Type type)
        {
            return _kernel.Get(type);
        }
    }
}
