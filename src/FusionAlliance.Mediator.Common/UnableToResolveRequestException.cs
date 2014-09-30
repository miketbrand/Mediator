using System;

namespace FusionAlliance.Mediator.Common
{
    /// <summary>
    /// This exception is thrown when the request cannot be resolved by the mediator.
    /// </summary>
    [Serializable]
    public class UnableToResolveRequestException : Exception
    {
        public UnableToResolveRequestException(string message)
            : base(message)
        {
        }

        public UnableToResolveRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
