using MediatR;
using OglasiSource.Core.Responses.Comment;
using OglasiSource.Core.Specifications.Comment;

namespace OglasiSource.Api.Cqrs.Queries.Comment
{
    public class GetCommentByEntityTypeListQuery : IRequest<CommentByEntityTypeListResponse>
    {
        public CommentSpecParams CommentSpecParams { get; set; }
    }
}
