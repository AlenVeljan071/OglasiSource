using OglasiSource.Core.Entities;

namespace OglasiSource.Core.Responses.User
{
    public class UserResponse
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public AddressEntity? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Avatar { get; set; }

    }
}
