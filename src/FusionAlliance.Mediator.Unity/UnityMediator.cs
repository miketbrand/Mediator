using System;
using FusionAlliance.Mediator.Common;
using Microsoft.Practices.Unity;

namespace FusionAlliance.Mediator.Unity
{
    /// <summary>
    /// Unity-specific implementation of the mediator pattern.
    /// </summary>
    public class UnityMediator : AbstractMediator
    {
        private readonly IUnityContainer _container;

        /// <summary>
        /// Create a new instance of a <see cref="UnityContainer"/>.
        /// </summary>
        /// <param name="container">Unity container.</param>
        public UnityMediator(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        public override object GetInstanceOfHandler(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
