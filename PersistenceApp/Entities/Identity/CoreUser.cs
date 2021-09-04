using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Entities.Identity
{
    public class CoreUser : IdentityUser<int>
    {
        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<int>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<int>> Tokens { get; set; }
        public virtual ICollection<IdentityUserRole<int>> UserRoles { get; set; }
    }
}
