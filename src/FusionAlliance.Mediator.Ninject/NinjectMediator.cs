using System;
using FusionAlliance.Mediator.Common;
using Ninject;

namespace FusionAlliance.Mediator.Ninject
{
    /// <summary>
    /// Ninject-specific implementation of a mediator class.
    /// </summary>
    /// <remarks>
    /// You may be tempted to override the OnDisposing method and dispose of the
    /// Ninject kernel. DO NOT DO THIS. In most applications, the kernel is created
    /// one time during application startup. Disposing of the kernel will remove
    /// all type bindings from the kernel definition.
    /// </remarks>
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

        public override object GetInstanceOfHandler(Type type)
        {
            return _kernel.Get(type);
        }
    }
}
