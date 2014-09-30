using System.Threading.Tasks;

namespace FusionAlliance.Mediator.Common
{
    public static class IMediatorExtensions
    {
        public static Task<TReply> RequestAsync<TReply>(this IMediator mediator, IRequest<TReply> request)
        {
            return Task.FromResult(mediator.Request(request));
        }
    }
}
