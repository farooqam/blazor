using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public class SeedIdentity
    {
        public static async Task Seed(
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            string[] roles = { "contributor", "reader", "owner", "administrator" };

            foreach (string role in roles)
            {
                if (await roleManager.FindByNameAsync(role) != null) continue;
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
