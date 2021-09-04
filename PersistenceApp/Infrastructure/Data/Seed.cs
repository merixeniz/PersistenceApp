using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class Seed
    {
        public static async Task SeedData(PerisstenceDbContext dbContext, UserManager<CoreUser> userManager)
        {
            try
            {
                if (!userManager.Users.Any())
                {
                    var users = new List<CoreUser>
                    {
                        new() { UserName = "Bob", Email = "bob@test.com"  },
                        new() { UserName = "Tom", Email = "tom@test.com"  },
                        new() { UserName = "Dave", Email = "dave@test.com"  },
                    };

                    foreach (var user in users)
                    {
                        await userManager.CreateAsync(user, "Pa$$w0rd");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
