using GainBase.Data.Configuration.Contracts;
using Microsoft.AspNetCore.Identity;

namespace GainBase.Data.Configuration
{
    public class IdentitySeeder : IIdentitySeeder
    {
        private const string AdminRole = "Admin";
        private const string UserRole = "User";

        private readonly string[] applicationRoles = new[] { AdminRole, UserRole };

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
                    IdentityResult identityRoleResult = await roleManager.CreateAsync(new IdentityRole(role));
                    if (!identityRoleResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Failed to create role '{role}'.");
                    }
                }
            }
        }

        public async Task SeedAdminUserAsync()
        {
            await SeedUserWithRoleAsync(
                id: "e59fe6bf-c819-4cd3-b737-d2a2469f3d79",
                username: "admin",
                email: "admin@gainbase.com",
                password: "Admin123!",
                role: AdminRole);
        }

        public async Task SeedDefaultUserAsync()
        {
            await SeedUserWithRoleAsync(
                id: "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                username: "SeedUser",
                email: "seeduser@gainbase.com",
                password: "SeedUser123!",
                role: UserRole);
        }

        private async Task SeedUserWithRoleAsync(string id, string username, string email, string password, string role)
        {
            IdentityUser? user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new IdentityUser
                {
                    Id = id,
                    UserName = username,
                    NormalizedUserName = username.ToUpperInvariant(),
                    Email = email,
                    NormalizedEmail = email.ToUpperInvariant(),
                    EmailConfirmed = true,
                };

                IdentityResult createResult = await userManager.CreateAsync(user, password);
                if (!createResult.Succeeded)
                {
                    throw new InvalidOperationException($"Failed to create user '{email}'.");
                }
            }

            bool isInRole = await userManager.IsInRoleAsync(user, role);
            if (!isInRole)
            {
                IdentityResult addToRoleResult = await userManager.AddToRoleAsync(user, role);
                if (!addToRoleResult.Succeeded)
                {
                    throw new InvalidOperationException($"Failed to add user '{email}' to role '{role}'.");
                }
            }
        }
    }
}
