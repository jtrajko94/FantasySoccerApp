using Microsoft.AspNetCore.Identity;

namespace FantasySoccerApp.MobileAppService.Models
{
    public partial class AspNetRoleClaims : IdentityRoleClaim<string>
    {
    }

    public partial class AspNetRoles : IdentityRole<string>
    {
        public AspNetRoles() { }
        public AspNetRoles(string role)
        {
            var identityRole = new IdentityRole(role);
            Name = identityRole.Name;
            NormalizedName = identityRole.Name;
            Id = identityRole.Id;
            ConcurrencyStamp = identityRole.ConcurrencyStamp;
        }
    }

    public partial class AspNetUserClaims : IdentityUserClaim<string>
    {
    }

    public partial class AspNetUserLogins : IdentityUserLogin<string>
    {
    }

    public partial class AspNetUserRoles : IdentityUserRole<string>
    {
    }

    public partial class AspNetUsers : IdentityUser
    {
        public AspNetUsers() { }
    }

    public partial class AspNetUserTokens : IdentityUserToken<string>
    {
    }
}
