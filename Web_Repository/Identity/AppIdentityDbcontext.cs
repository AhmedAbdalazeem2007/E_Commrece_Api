





namespace Web_Repository.Identity
{
    public class AppIdentityDbcontext:IdentityDbContext<ApplicationUser>
    {
        public AppIdentityDbcontext(DbContextOptions<AppIdentityDbcontext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
