using Microsoft.AspNetCore.Identity;

namespace List.Features.Account.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Plan { get; set; }
    }
}
