using MediatR;
using OglasiSource.Core.Responses.Comment;

namespace OglasiSource.Api.Cqrs.Queries.Comment
{
    public class GetCommentModalQuery : IRequest<GetCommentModalResponse>
    {
    }
}
