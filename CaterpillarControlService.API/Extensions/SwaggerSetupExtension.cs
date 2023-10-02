using Microsoft.OpenApi.Models;

namespace CaterpillarControlService.API.Extensions
{
    public static class SwaggerSetupExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CATERPILLAR CONTROL SERVICES API",
                    Description = "This API Provides all endpoints for Caterpillar Control System ",
                });

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "CaterpillarControlServiceAPI v1");
                options.DefaultModelsExpandDepth(-1);


            });


            return app;
        }
    }
}
