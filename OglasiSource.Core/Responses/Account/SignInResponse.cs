using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiSource.Core.Responses.Account
{
    public class SignInResponse
    {
        public string Token { get; set; }
        public int AplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Avatar { get; set; }
        public string? RefreshToken { get; set; }
    }
}
