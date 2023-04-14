namespace OglasiSource.Core.Specifications.Comment
{
    public class CommentSpecification : BaseSpecification<Entities.Comment>
    {
        public CommentSpecification(CommentSpecParams commentSpecParams) : base(x =>
        (!commentSpecParams.UserId.HasValue))
        {
            AddInclude(x => x.ApplicationUser);
            AddInclude(x => x.EntityTypeComment);
            AddOrderBy(x => x.UpdatedAt,false);
        }
        public CommentSpecification(int Id, int companyId) : base(x =>
        (x.Id == Id)) 
        {
            AddInclude(x => x.ApplicationUser);
            AddInclude(x => x.EntityTypeComment);
        }
    }
}
