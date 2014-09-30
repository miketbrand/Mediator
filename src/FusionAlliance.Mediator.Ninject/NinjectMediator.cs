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

        protected override object GetInstanceOfHandler(Type type)
        {
            return _kernel.Get(type);
        }
    }
}
