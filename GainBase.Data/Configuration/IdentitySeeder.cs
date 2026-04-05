using GainBase.Data.Configuration.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace GainBase.Data.Configuration
{
    public class IdentitySeeder : IIdentitySeeder
    {
        private readonly string[] applicationRoles = new[] { "Admin", "User" };
        
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public IdentitySeeder(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        } 

        public async Task SeedRolesAsync()
        {
            foreach (string role in applicationRoles)
            {
                bool roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    IdentityRole newRole = new IdentityRole(role);

                    IdentityResult identityRoleResult = await roleManager.CreateAsync(newRole);
                    if (!identityRoleResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Failed to create role '{role}'.");
                    }

                }
            }
        }

        public async Task SeedAdminUserAsync()
        {
            string adminId = "e59fe6bf-c819-4cd3-b737-d2a2469f3d79";
            string adminUsername = "admin";
            string adminNormalizedUsername = adminUsername.ToUpperInvariant();
            string adminEmail = "admin@gainbase.com";
            string adminPassword = "Admin123!";

            IdentityUser? adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                IdentityUser user = new IdentityUser
                {
                    Id = adminId,
                    UserName = adminUsername,
                    NormalizedUserName = adminNormalizedUsername,
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpperInvariant(),
                    EmailConfirmed = true,
                };

                PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
                user.PasswordHash = hasher.HashPassword(user, adminPassword);

                IdentityResult result = await userManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"Failed to create admin user.");
                }

                adminUser = user;
            }

            bool isInRole = await userManager.IsInRoleAsync(adminUser, applicationRoles[0]);
            if (!isInRole)
            {
                IdentityResult result = await userManager.AddToRoleAsync(adminUser, applicationRoles[0]);
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"Failed to add admin user to role.");
                }
            }
        }
    }
}
