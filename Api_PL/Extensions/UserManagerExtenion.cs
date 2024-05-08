using System.Security.Claims;

namespace Api_PL.Extensions
{
    public static class UserManagerExtenion
    {
        public static async Task<ApplicationUser> FindUserWithAddressByEmail(this UserManager<ApplicationUser> userManager, ClaimsPrincipal User)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.Users.Include(x => x.Address).FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}
