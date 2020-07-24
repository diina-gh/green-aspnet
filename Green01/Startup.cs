using Green01.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using MetierPlant.Models;
using System;

[assembly: OwinStartupAttribute(typeof(Green01.Startup))]
namespace Green01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            ServiceMetierPlants.Service1Client service = new ServiceMetierPlants.Service1Client();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            try
            {
                if (!roleManager.RoleExists("Admin"))
                {
                    // first we create Admin rool  
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);
                    Profil p = new Profil();
                    p.LibelleProfil = "Admin";
                    service.AddProfil(p);

                    var user = new ApplicationUser();
                    user.UserName = "Admin";
                    user.Email = "dina@gmail.com";
                    string userPWD = "P@ssword01";
                    var chkUser = UserManager.Create(user, userPWD);

                    Utilisateur u = new Utilisateur();
                    u.NomPrenomU = "Anid";
                    u.IdentifiantU = user.UserName;
                    u.EmailU = user.Email;
                    u.TelU = "770123456";
                    u.IdUser = user.Id;
                    service.AddUtilisateur(u);

                    //Add default User to Role Admin  
                    if (chkUser.Succeeded)
                    {
                        var result1 = UserManager.AddToRole(user.Id, "Admin");
                    }
                }

                // creating Creating AGENT DE SAISIE role   
                if (!roleManager.RoleExists("Medecin"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Medecin";
                    roleManager.Create(role);
                    Profil p = new Profil();
                    p.LibelleProfil = "Medecin";
                    service.AddProfil(p);
                    //db.profils.Add(p);
                    //db.SaveChanges();
                }
                // creating Creating AGENT DE SAISIE role   
                if (!roleManager.RoleExists("Sécrétaire"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Sécrétaire";
                    roleManager.Create(role);
                    Profil p = new Profil();
                    p.LibelleProfil = "Sécrétaire";
                    service.AddProfil(p);
                    //db.profils.Add(p);
                    //db.SaveChanges();
                }
                var leUser = UserManager.FindByName("Hady");
                if (leUser == null)
                {
                    var user = new ApplicationUser();
                    user.UserName = "Dina";
                    user.Email = "dina@gmail.com";
                    string userPWD = "P@ssword01";
                    var chkUser = UserManager.Create(user, userPWD);

                    Utilisateur u = new Utilisateur();
                    u.NomPrenomU = "Dina";
                    u.IdentifiantU = user.UserName;
                    u.EmailU = user.Email;
                    u.TelU = "781234567";
                    u.IdUser = user.Id;
                    service.AddUtilisateur(u);

                    if (chkUser.Succeeded)
                    {
                        var result1 = UserManager.AddToRole(user.Id, "Sécrétaire");
                    }
                }

            }
            catch (Exception ex)
            {

            }


           
        }
    }
 }