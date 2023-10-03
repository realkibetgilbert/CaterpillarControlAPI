using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Core.Utils.Enums;
using Microsoft.AspNetCore.Identity;

namespace CaterpillarControlService.API.Infrastructure.SeedData
{
    public class CaterpillarControlSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole<long>> roleManager, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!roleManager.Roles.Any())
                {
                    await SeedRider(roleManager);
                    
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<CaterpillarControlSeeder>();

                logger.LogError(ex.Message);
            }
        }

        private static async Task SeedRider(RoleManager<IdentityRole<long>> roleManager)
        {
            var role = new IdentityRole<long>()
            {
                Name = CatepillarConstants.RIDER
            };

            await roleManager.CreateAsync(role);
        }

        public static async Task SeedRiderAsync(UserManager<User> userManager,
            ILoggerFactory loggerFactory,
            RoleManager<IdentityRole<long>> roleManager, IConfiguration config)
        {
            try
            {
                if (!userManager.Users.Any())
                {
                    var user = new User()
                    {
                        Email = config["RiderSettings:Email"],
                        UserName = config["RiderSettings:UserName"],
                    };

                    var res = await userManager.CreateAsync(user, config["RiderSettings:Password"]);

                    await userManager.AddToRoleAsync(user, CatepillarConstants.RIDER);
                }
            }

            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<CaterpillarControlSeeder>();

                logger.LogError(ex.Message);
            }
        }

    }
}
