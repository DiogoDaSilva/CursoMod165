using Microsoft.AspNetCore.Identity;

namespace CursoMod165.Data.SeedDatabase
{
    public class SeedDatabase
    {

        public static void Seed(ApplicationDbContext context,
                                UserManager<IdentityUser> userManager,
                                RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager).Wait();
            SeedUsers(userManager).Wait();
        }

        private static async Task SeedUsers(UserManager<IdentityUser> userManager)
        {
            var dbAdmin = await userManager.FindByNameAsync(CursoMod165Constants.USERS.ADMIN.USERNAME);

            if (dbAdmin == null)
            {
                IdentityUser userAdmin = new IdentityUser()
                {
                    UserName = CursoMod165Constants.USERS.ADMIN.USERNAME
                };
                var result = await userManager.CreateAsync(userAdmin, CursoMod165Constants.USERS.ADMIN.PASSWORD);

                if (result.Succeeded == true)
                {
                    dbAdmin = await userManager.FindByNameAsync(CursoMod165Constants.USERS.ADMIN.USERNAME);
                    await userManager.AddToRoleAsync(dbAdmin!, CursoMod165Constants.ROLES.ADMIN);
                }
            }

            var dbAdministrative = await userManager.FindByNameAsync(CursoMod165Constants.USERS.ADMINISTRATIVE.USERNAME);

            if (dbAdministrative == null)
            {
                IdentityUser userAdministrative = new IdentityUser
                {
                    UserName = CursoMod165Constants.USERS.ADMINISTRATIVE.USERNAME
                };
                var result = await userManager.CreateAsync(userAdministrative, CursoMod165Constants.USERS.ADMINISTRATIVE.PASSWORD);

                if (result.Succeeded == true)
                {
                    dbAdministrative = await userManager.FindByNameAsync(CursoMod165Constants.USERS.ADMINISTRATIVE.USERNAME);
                    await userManager.AddToRoleAsync(dbAdministrative!, CursoMod165Constants.ROLES.ADMINISTRATIVE);
                }

            }

            var dbDriver = await userManager.FindByNameAsync(CursoMod165Constants.USERS.DRIVER.USERNAME);

            if (dbDriver == null)
            {
                IdentityUser userDriver = new IdentityUser()
                {
                    UserName = CursoMod165Constants.USERS.DRIVER.USERNAME
                };
                var result = await userManager.CreateAsync(userDriver, CursoMod165Constants.USERS.DRIVER.PASSWORD);

                if (result.Succeeded == true)
                {
                    dbDriver = await userManager.FindByNameAsync(CursoMod165Constants.USERS.DRIVER.USERNAME);
                    await userManager.AddToRoleAsync(dbDriver!, CursoMod165Constants.ROLES.DRIVER);
                }
            }

        }


        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            var roleCheck = await roleManager.RoleExistsAsync(CursoMod165Constants.ROLES.ADMIN);

            if (!roleCheck)
            {
                var adminRole = new IdentityRole
                {
                    Name = CursoMod165Constants.ROLES.ADMIN
                };

                await roleManager.CreateAsync(adminRole);
            }

            roleCheck = await roleManager.RoleExistsAsync(CursoMod165Constants.ROLES.ADMINISTRATIVE);

            if (!roleCheck)
            {
                var administrativeRole = new IdentityRole
                {
                    Name = CursoMod165Constants.ROLES.ADMINISTRATIVE
                };

                await roleManager.CreateAsync(administrativeRole);
            }

            roleCheck = await roleManager.RoleExistsAsync(CursoMod165Constants.ROLES.DRIVER);

            if (!roleCheck)
            {
                var driverRole = new IdentityRole
                {
                    Name = CursoMod165Constants.ROLES.DRIVER
                };

                await roleManager.CreateAsync(driverRole);
            }

            roleCheck = await roleManager.RoleExistsAsync(CursoMod165Constants.ROLES.HEALTH_STAFF);

            if (!roleCheck)
            {
                var healthStaffRole = new IdentityRole
                {
                    Name = CursoMod165Constants.ROLES.HEALTH_STAFF
                };

                await roleManager.CreateAsync(healthStaffRole);
            }


        }
    }
}
