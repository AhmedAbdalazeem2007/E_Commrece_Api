


namespace Api_Core.Services
{
    public interface ITokenServices
    {
        Task<string> CreateTokenAsync(ApplicationUser applicationUser,UserManager<ApplicationUser> userManager);
    }
}
