using System.Threading.Tasks;

namespace FusionAlliance.Mediator.Common
{
    public static class IMediatorExtensions
    {
        /// <summary>
        /// Asynchronously handle the request. The returned task will be started.
        /// </summary>
        /// <typeparam name="TReply">Type of reply.</typeparam>
        /// <param name="mediator">Mediator.</param>
        /// <param name="request">Request.</param>
        /// <returns>Task.</returns>
        public static Task<TReply> RequestAsync<TReply>(this IMediator mediator, IRequest<TReply> request)
        {
            var task = new Task<TReply>(() => mediator.Request(request));
            task.Start();
            return task;
        }
    }
}
