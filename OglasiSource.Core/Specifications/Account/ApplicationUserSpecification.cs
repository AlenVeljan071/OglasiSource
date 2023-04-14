namespace OglasiSource.Core.Specifications.Account
{
    public class ApplicationUserSpecification : BaseSpecification<Entities.ApplicationUser>
    {

        public ApplicationUserSpecification(int Id) : base(x =>
         (x.Id == Id))
        {
            AddInclude(x => x.Ratings);
            AddInclude(x => x.Reviews);
        }
    }
}
