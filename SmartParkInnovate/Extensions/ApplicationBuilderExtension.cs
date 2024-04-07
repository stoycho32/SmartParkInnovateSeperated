using Microsoft.AspNetCore.Identity;
using SmartParkInnovate.Infrastructure.Data.Models;
using static SmartParkInnovate.Infrastructure.Data.Constants.RoleConstants;

namespace SmartParkInnovate.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            UserManager<Worker> userManager = scope.ServiceProvider.GetRequiredService<UserManager<Worker>>();
            RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdminRole) == false)
            {
                IdentityRole role = new IdentityRole(AdminRole);
                await roleManager.CreateAsync(role);

                Worker admin = await userManager.FindByEmailAsync("admin@mail.com");

                if (admin != null)
                {
                    await userManager.AddToRoleAsync(admin, role.Name);
                }
            }

        }
    }
}
