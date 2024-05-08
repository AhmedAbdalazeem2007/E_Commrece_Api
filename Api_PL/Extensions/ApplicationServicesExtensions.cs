 

namespace Api_PL.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));
            services.Configure<ApiBehaviorOptions>(
     options =>
     {
         options.InvalidModelStateResponseFactory = (actioncontext) =>
         {
             var errors = actioncontext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                     .SelectMany(p => p.Value.Errors)
                     .Select(e => e.ErrorMessage)
                     .ToArray();
             var validation = new ApiValidationErrorResponse()
             {
                 Errors = errors,
             };
             return new BadRequestObjectResult(validation);
         };
     });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            return services;
        }
    }
}
