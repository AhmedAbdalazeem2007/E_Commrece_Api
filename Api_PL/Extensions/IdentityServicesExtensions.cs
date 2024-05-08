



using Microsoft.IdentityModel.Tokens;

namespace Api_PL.Extensions
{
    public static class IdentityServicesExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<ITokenServices, TokenServices>();
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                }
                ).AddEntityFrameworkStores<AppIdentityDbcontext>();
            services.AddAuthentication(options => {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = configuration["Jwt:ValidIssuer"],
                        ValidateAudience = true,
                        ValidAudience = configuration["ValidAudience"],
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWt:Key"]))
                    };
                });
        
            return services;
        }
    }
}
