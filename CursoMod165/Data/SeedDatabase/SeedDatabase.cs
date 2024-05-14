using Microsoft.AspNetCore.Identity;



namespace CursoMod165.Data.SeedDatabase
{
    public class SeedDatabase
    {

        public static void Seed(ApplicationDbContext context,
                                UserManager<IdentityUser> userManager,
                                RoleManager<IdentityRole> roleManager)
        {
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
            }

            var dbAdministrative = await userManager.FindByNameAsync(CursoMod165Constants.USERS.ADMINISTRATIVE.USERNAME);

            if (dbAdministrative == null)
            {
                IdentityUser userAdministrative = new IdentityUser()
                {
                    UserName = CursoMod165Constants.USERS.ADMINISTRATIVE.USERNAME
                };
                var result = await userManager.CreateAsync(userAdministrative, CursoMod165Constants.USERS.ADMINISTRATIVE.PASSWORD);
            }

            var dbDriver = await userManager.FindByNameAsync(CursoMod165Constants.USERS.DRIVER.USERNAME);

            if (dbDriver == null)
            {
                IdentityUser userDriver = new IdentityUser()
                {
                    UserName = CursoMod165Constants.USERS.DRIVER.USERNAME
                };
                var result = await userManager.CreateAsync(userDriver, CursoMod165Constants.USERS.DRIVER.PASSWORD);
            }

        }
    }
}
