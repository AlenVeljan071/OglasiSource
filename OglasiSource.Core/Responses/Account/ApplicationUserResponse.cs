using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiSource.Core.Responses.Account
{
    public class ApplicationUserResponse
    {
        public int AplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Avatar { get; set; }
        public AddressEntity? Address { get; set; }
        public string? Phone { get; set; }
        public int UpCount { get; set; }
        public int DownCount { get; set; }
        public int Rating { get; set; }
      
        public string FullName;
    }
}
