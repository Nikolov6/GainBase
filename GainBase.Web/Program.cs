using GainBase.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GainBase.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string? connectionString = builder.Configuration
                .GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services
                .AddDefaultIdentity<IdentityUser>(options => 
                {
                    ConfigureIdentity(options, builder.Configuration);
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }

        private static void ConfigureIdentity(IdentityOptions options, ConfigurationManager configuration)
        {
            options.SignIn.RequireConfirmedAccount = configuration.GetValue<bool>("IdentityOptions:SignIn:RequireConfirmedAccount");
            options.SignIn.RequireConfirmedEmail = configuration.GetValue<bool>("IdentityOptions:SignIn:RequireConfirmedEmail");

            options.User.RequireUniqueEmail = configuration.GetValue<bool>("IdentityOptions:User:RequireUniqueEmail");

            options.Lockout.MaxFailedAccessAttempts = configuration.GetValue<int>("IdentityOptions:Lockout:MaxFailedAccessAttempts");
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(configuration.GetValue<int>("IdentityOptions:Lockout:DefaultLockoutTimeSpan"));

            options.Password.RequireDigit = configuration.GetValue<bool>("IdentityOptions:Password:RequireDigit");
            options.Password.RequireLowercase = configuration.GetValue<bool>("IdentityOptions:Password:RequireLowercase");
            options.Password.RequireUppercase = configuration.GetValue<bool>("IdentityOptions:Password:RequireUppercase");
            options.Password.RequireNonAlphanumeric = configuration.GetValue<bool>("IdentityOptions:Password:RequireNonAlphanumeric");
            options.Password.RequiredLength = configuration.GetValue<int>("IdentityOptions:Password:RequiredLength");
        }
    }
}