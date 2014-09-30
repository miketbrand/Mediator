using System;

namespace FusionAlliance.Mediator.Common
{
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
