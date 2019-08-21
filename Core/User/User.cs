using Microsoft.AspNetCore.Identity;

namespace BugTrackerGetIT.Core.User
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string Token { get; set; }
    }
}