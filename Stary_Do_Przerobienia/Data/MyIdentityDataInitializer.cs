using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;

namespace WebApp1.Data
{
    public class MyIdentityDataInitializer
    {
        public static void SeedData(UserManager<PatientAccount> userManager,
       RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        // name - poprawny adres email
        // password - min 8 znaków, mała i duża litera, cyfra i znak specjalny
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        public static void SeedOneUser(UserManager<PatientAccount> userManager,
                                 string name, string password, string role = null)
        {
            System.Diagnostics.Debug.WriteLine("\n\n\nW SeedOneUser\n\n\n");
            if (userManager.FindByNameAsync(name).Result == null)
            {
                PatientAccount user = new PatientAccount
                {
                    UserName = name, // musi być taki sam jak email, inaczej nie zadziała
                    Email = name,
                    TelephoneNumber = "000000000",
                    AccountOwnerID = -1
                };
                IdentityResult result = userManager.CreateAsync(user, password).Result;
                if (result.Succeeded && role != null)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                    System.Diagnostics.Debug.WriteLine("\n\n\nUdalo sie dodac!!\n\n\n");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("\n\n\nJuz jest taki uzytkownik!\n\n\n");
            }
        }
        public static void SeedUsers(UserManager<PatientAccount> userManager)
        {
            SeedOneUser(userManager, "adminuser@localhost", "Admin123@", "Admin");
            System.Diagnostics.Debug.WriteLine("\n\n\nW seed users!\n\n\n");
        }

    }
}
