










namespace Api_PL
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddDbContext<FirstDataBase>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddDbContext<AppIdentityDbcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentitytConnection"));
            });
            builder.Services.AddSwaggerServices();
            builder.Services.AddApplicationServices();
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddSingleton<IConnectionMultiplexer>(
                s =>
                {
                    var conectionstri = builder.Configuration.GetConnectionString("Redis");
                    return ConnectionMultiplexer.Connect(conectionstri);
                }
                );
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                     .AddEntityFrameworkStores<AppIdentityDbcontext>();
            builder.Services.Configure<Email>(builder.Configuration.GetSection("MailSettings"));
            var app = builder.Build(); 
            var scop = app.Services.CreateScope();
            var services = scop.ServiceProvider;
            var loggerfactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbcontext = services.GetRequiredService<FirstDataBase>();
                await dbcontext.Database.MigrateAsync();
                await StoreContextSeeding.seed(dbcontext);
                var identitycontext = services.GetRequiredService<AppIdentityDbcontext>();
                await identitycontext.Database.MigrateAsync();
                var user = services.GetRequiredService<UserManager<ApplicationUser>>();
                await AppIdentityDbcontextSeed.SeedUsersAsync(user);
            }
            catch (Exception ex)
            {
                var logger = loggerfactory.CreateLogger<Program>();
                logger.LogError(ex, ex.Message);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger_1();
            }
            app.UseStatusCodePagesWithReExecute("error{0}");
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseRouting();


            
            app.Run();
        }
    }
}
