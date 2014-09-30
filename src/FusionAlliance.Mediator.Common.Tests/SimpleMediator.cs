using System;
using System.Collections.Generic;

namespace FusionAlliance.Mediator.Common.Tests
{
    public class SimpleMediator : AbstractMediator
    {
        private readonly IDictionary<Type, Type> _typeDictionary = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type concreteType)
        {
            _typeDictionary.Add(interfaceType, concreteType);
        }

        protected override object GetInstanceOfHandler(Type type)
        {
            var concreteType = _typeDictionary[type];
            object instanceOfHandler = Activator.CreateInstance(concreteType);
            return instanceOfHandler;
        }
    }
}
