using System;
using FusionAlliance.Mediator.Common;
using Microsoft.Practices.Unity;

namespace FusionAlliance.Mediator.Unity
{
    public class UnityMediator : AbstractMediator
    {
        private readonly IUnityContainer _container;

        public UnityMediator(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        protected override object GetInstanceOfHandler(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
