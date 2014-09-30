using System;
using FusionAlliance.Mediator.Common;
using Ninject;

namespace FusionAlliance.Mediator.Ninject
{
    /// <summary>
    /// Ninject-specific implementation of a mediator class.
    /// </summary>
    public class NinjectMediator : AbstractMediator
    {
        private readonly IKernel _kernel;

        /// <summary>
        /// Creates a new instance of a <see cref="NinjectMediator"/>.
        /// </summary>
        /// <param name="kernel">Instance of Ninject kernel.</param>
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
