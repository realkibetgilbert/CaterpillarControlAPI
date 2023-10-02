using CaterpillarControlService.API.Core.Interfaces;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Core.Utils;
using CaterpillarControlService.API.Infrastructure.ApplicationDbContext;
using CaterpillarControlService.API.Infrastructure.SqlServerImplementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CaterpillarControlService.API.Extensions
{

    public static class ApplicationServiceExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {

            services.AddControllers();

            services.AddEndpointsApiExplorer();


            services.AddDbContext<CaterpillarDbContext>(options =>
               options.UseSqlServer(config.GetConnectionString("CaterpillarConnectionstring")));

            services.AddScoped<IControlStationRepository, ControlStationRepository>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddIdentityCore<User>()
.AddRoles<IdentityRole<long>>()
.AddTokenProvider<DataProtectorTokenProvider<User>>("Caterpillar")
.AddEntityFrameworkStores<CaterpillarDbContext>()
.AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   options.TokenValidationParameters = new TokenValidationParameters
   {
       ValidateIssuer = true,
       ValidateAudience = true,
       ValidateLifetime = true,
       ValidateIssuerSigningKey = true,
       ValidIssuer = config["Jwt:Issuer"],
       ValidAudience = config["Jwt:Audience"],
       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))

   });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;
            }
);

            services.AddCors();

            return services;

        }
        public static IApplicationBuilder UseApplicationServices(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment env)
        {

            app.UseCors(x => x
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            return app;

        }
    }
}
