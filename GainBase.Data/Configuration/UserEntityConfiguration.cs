using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GainBase.Data.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> entity)
        {
            entity.HasData(users);
        }

        private readonly IEnumerable<IdentityUser> users = new IdentityUser[]
        {
            CreateUser(
                "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                "seeduser@gainbase.com",
                "SeedUser",
                "SeedUser123!"
            ),
        };

        private static IdentityUser CreateUser(string id, string email, string username, string password)
        {
            IdentityUser user = new IdentityUser
            {
                Id = id,
                UserName = username,
                NormalizedUserName = username.ToUpperInvariant(),
                Email = email,
                NormalizedEmail = email.ToUpperInvariant(),
                EmailConfirmed = true,
            };

            PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = hasher.HashPassword(user, password);

            return user;
        }
    }
}