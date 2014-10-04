using System;

namespace FusionAlliance.Mediator.Common
{
    /// <summary>
    /// Utility class to get the Handle() method on the request handler.
    /// </summary>
    public class RequestHandlerMethodResolver
    {
        private readonly IRequestHandlerInstanceResolver _resolver;

        public RequestHandlerMethodResolver(IRequestHandlerInstanceResolver resolver)
        {
            if (resolver == null) throw new ArgumentNullException("resolver");

            _resolver = resolver;
        }

        /// <summary>
        /// Get the Handle() method for the given type of request.
        /// </summary>
        /// <typeparam name="TReply">Reply type.</typeparam>
        /// <param name="request">Request.</param>
        /// <returns>Request handler info.</returns>
        public RequestHandlerInfo GetHandlerMethod<TReply>(IRequest<TReply> request)
        {
            Type requestType = request.GetType();
            Type replyType = typeof(TReply);
            try
            {
                RequestHandlerInfo requestHandlerInfo = GetRequestHandlerInfo(typeof(IRequestHandler<,>), requestType, replyType);
                requestHandlerInfo.HandlerInstance = _resolver.GetInstanceOfHandler(requestHandlerInfo.GenericType);
                return requestHandlerInfo;
            }
            catch (Exception e)
            {
                var message = string.Format("Unable to resolve request.\nRequested type: {0}\nRequest: {1}", typeof(IRequest<TReply>), request);
                throw new UnableToResolveRequestException(message, e);
            }
        }

        private static RequestHandlerInfo GetRequestHandlerInfo(Type requestHandlerType, Type requestType, Type replyType, string methodName = "Handle")
        {
            var genericType = requestHandlerType.MakeGenericType(requestType, replyType);
            var method = genericType.GetMethod(methodName);
            return new RequestHandlerInfo
            {
                GenericType = genericType,
                Method = method
            };
        }
    }
}
