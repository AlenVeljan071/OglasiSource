using MediatR;
using OglasiSource.Api.Cqrs.Queries.Comment;
using OglasiSource.Core.Constants;
using OglasiSource.Core.Responses.Comment;

namespace OglasiSource.Api.Handlers.Comment
{
    public class GetCommentModalHandler : IRequestHandler<GetCommentModalQuery, GetCommentModalResponse>
    {
        public async Task<GetCommentModalResponse> Handle(GetCommentModalQuery request, CancellationToken cancellationToken)
        {
            var response = new GetCommentModalResponse
            {
                EntityTypeComment = DictionaryExtensions.GetValues(Constants.EntityTypeComment)
            };
            return await Task.FromResult(response);
        }
    }
}
