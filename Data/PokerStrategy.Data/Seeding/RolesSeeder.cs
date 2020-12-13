namespace PokerStrategy.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using PokerStrategy.Common;
    using PokerStrategy.Data.Models;

    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await this.SeedRoleAsync(roleManager, GlobalConstants.AdminRoleName);

            if (!dbContext.Users.Any(x => x.Email == "nsavov21@abv.bg"))
            {
                await this.CreateInitialAdmin(userManager, roleManager);
            }

            if (!dbContext.Users.Any(x => x.Email == "gunsnrosesfan88@gmail.com"))
            {
                await this.CreateInitialMember(userManager, roleManager);
            }
        }

        private async Task CreateInitialAdmin(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            var admin = new ApplicationUser
            {
                Email = "nsavov21@abv.bg",
                UserName = "nsavov21@abv.bg",
                EmailConfirmed = true,
                PhoneNumber = "987654321",
                DisplayName = "Da1337DoOD",
                ImageUrl = "https://avatars3.githubusercontent.com/u/38983976?s=460&u=30e11edc2b4ea1929be9b5817c5673062334ac7d&v=4",
                Id = "THEveryBESTadminID",
            };

            await userManager.CreateAsync(admin, "123456");

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new ApplicationRole
                {
                    Name = "Admin",
                });
            }

            await userManager.AddToRoleAsync(admin, "Admin");
            return;
        }

        private async Task CreateInitialMember(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            var member = new ApplicationUser
            {
                Email = "gunsnrosesfan88@gmail.com",
                UserName = "gunsnrosesfan88@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "123456789",
                DisplayName = "GunsNRosesFan",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTa0ogMc3emzZtPzOih0weBBXa6qRCOUMkSXQ&usqp=CAU",
            };

            await userManager.CreateAsync(member, "123456");

            if (!await roleManager.RoleExistsAsync("Member"))
            {
                await roleManager.CreateAsync(new ApplicationRole
                {
                    Name = "Member",
                });
            }

            await userManager.AddToRoleAsync(member, "Member");
            return;
        }

        private async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
