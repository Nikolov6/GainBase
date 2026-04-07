namespace GainBase.Data.Configuration.Contracts
{
    public interface IIdentitySeeder
    {
        Task SeedRolesAsync();

        Task SeedAdminUserAsync();

        Task SeedDefaultUserAsync();
    }
}
