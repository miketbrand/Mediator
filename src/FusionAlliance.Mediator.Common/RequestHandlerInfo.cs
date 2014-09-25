using System;
using System.Reflection;

namespace FusionAlliance.Mediator.Common
{
    public class RequestHandlerInfo
    {
        public Type GenericType { get; set; }

        public MethodInfo Method { get; set; }
    }
}
