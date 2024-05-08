





namespace Api_Sercices
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration configuration;

        public TokenServices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(ApplicationUser user, UserManager<ApplicationUser> userManager)
        {
            var authcliam = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName,user.DisplayName),
                new Claim(ClaimTypes.Email,user.Email),
            };
            var userrols = await userManager.GetRolesAsync(user);
            foreach (var claim in userrols)
            {
                authcliam.Add(new Claim(ClaimTypes.Role, claim));
            }
            var authkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWt:Key"]));
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:ValidIssuer"],
                audience: configuration["Jwt:ValidAudience"],
                expires: DateTime.Now.AddDays(double.Parse(configuration["DurationInDays"])),
               claims: authcliam,
               signingCredentials: new SigningCredentials(authkey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
