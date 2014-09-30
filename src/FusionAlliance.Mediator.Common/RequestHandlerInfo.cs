using System;
using System.Reflection;

namespace FusionAlliance.Mediator.Common
{
    /// <summary>
    /// Simple DTO to give information about the request handler.
    /// </summary>
    public class RequestHandlerInfo
    {
        /// <summary>
        /// Generic type of the handler class.
        /// </summary>
        public Type GenericType { get; set; }

        /// <summary>
        /// Handler method.
        /// </summary>
        public MethodInfo Method { get; set; }
    }
}
