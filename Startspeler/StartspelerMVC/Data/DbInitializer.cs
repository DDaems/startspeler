using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StartspelerMVC.Models;
using System;
using System.Threading.Tasks;

namespace StartspelerMVC.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var ctx = serviceProvider.GetRequiredService<StartspelerContext>();
            ctx.Database.EnsureCreated();

            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var _logger = serviceProvider.GetRequiredService<ILogger<IdentityError>>();
            var roleName = "Admin";
            IdentityResult result;

            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (result.Succeeded)
                {
                    var _userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                    var config = serviceProvider.GetRequiredService<IConfiguration>();
                    var admin = await _userManager.FindByEmailAsync(config["Admin:Email"]);

                    if (admin == null)
                    {
                        admin = new User()
                        {
                            UserName = config["Admin:Alias"],
                            Achternaam = config["Admin:Achternaam"],
                            Voornaam = config["Admin:Voornaam"],
                            Email = config["Admin:Email"],
                            EmailConfirmed = true
                        };

                        result = await _userManager.CreateAsync(admin, config["Admin:Password"]);
                        if (result.Succeeded)
                        {
                            result = await _userManager.AddToRoleAsync(admin, roleName);
                            if (!result.Succeeded)
                            {
                                _logger.LogWarning("Admin privileges gebruiker aanmaken is gefaald.");
                            }
                        }
                    }
                }
            }
        }
    }
}