using System.Security.Claims;
using System.Security.Principal;

namespace Common
{
    public static class IdentityExtensions
    {
        public static int GetClaimId (this IIdentity identity)
        {
            ClaimsIdentity claims = identity as ClaimsIdentity;
            Claim claim = claims?.FindFirst("sub");

            if (claim == null)
                return -1;

            return int.Parse(claim.Value);
        }
    }
}
