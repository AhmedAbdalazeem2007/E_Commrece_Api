


namespace Web_Repository.Identity
{
    public class AppIdentityDbcontextSeed
    {
        public AppIdentityDbcontextSeed()
        {
            
        }
        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    DisplayName = "Ahmed",
                    Email = "ahmedmon997@gmail.com",
                    UserName = "ahmedmon",
                    PhoneNumber = "011596"
                };
                await userManager.CreateAsync(user, "kfkf");
            }

        }
    }
}
