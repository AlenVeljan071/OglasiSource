using OglasiSource.Core.Helpers;


namespace OglasiSource.Core.Responses.Comment
{
    public class CommentByEntityTypeListResponse
    {
        public Pagination<CommentResponse> Pagination { get; set; }
    }
}
