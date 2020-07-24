using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Green01.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using MetierPlant.Models;


using Green01.Logic;
using Green01.App_Start;
using Green01;

namespace ImlementationSecurite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UtilisateursController : Controller
    {
        private Green01.ServiceMetierPlants.Service1Client service = new Green01.ServiceMetierPlants.Service1Client();

        private ApplicationUserManager _userManager;
        public UtilisateursController()
        {
        }
        public UtilisateursController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Utilisateurs
        public async Task<ActionResult> Index(string IdentifiantU)
        {
            ViewBag.IdentifiantU = !string.IsNullOrEmpty(IdentifiantU) ? IdentifiantU : null;
            var ut = service.ListUtilisateur().ToList();
            if (!string.IsNullOrEmpty(IdentifiantU))
            {
                ut = ut.Where(a => a.IdentifiantU.ToUpper().Contains(IdentifiantU.ToUpper())).ToList();
            }
            return View(ut.ToList());
        }

        // GET: Utilisateurs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = service.getUtilisateurById(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            ViewBag.Profil = service.ListProfil();
            return View();
        }

        // POST: Utilisateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdU,NomPrenomU,IdentifiantU,EmailU,TelU,IdUser")] Utilisateur utilisateur, string Profil)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = utilisateur.IdentifiantU, Email = utilisateur.EmailU };
                var result = await UserManager.CreateAsync(user, "Passer@123");
                if (result.Succeeded)
                {
                    var chkUser = UserManager.AddToRole(user.Id, Profil);
                    utilisateur.IdUser = user.Id;
                    service.AddUtilisateur(utilisateur);
                    this.Flash("Utilisateur créé avec succés", FlashLevel.Success);

                    // Envoyer un message électronique avec ce lien
                    string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    ////await UserManager.SendEmailAsync(user.Id, "Réinitialiser le mot de passe", "Réinitialisez votre mot de passe en cliquant <a href=\"" + callbackUrl + "\">ici</a>");
                    GMailer mail = new GMailer();
                    mail.sendMail(user.Email, "Reinitialisation mot de passe", "Réinitialisez votre mot de passe en cliquant <a href=\"" + callbackUrl + "\">ici</a>");

                    return RedirectToAction("Index");
                }
            }
            this.Flash("Erreur création Utilisateur", FlashLevel.Warning);
            return View(utilisateur);
        }

        // GET: Utilisateurs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = service.getUtilisateurById(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdU,NomPrenomU,IdentifiantU,EmailU,TelU,IdUser")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(utilisateur.EmailU);
                if (user != null)
                {
                    user.UserName = utilisateur.IdentifiantU;
                    var chkUser = await UserManager.UpdateAsync(user);

                    service.UpdateUtilisateur(utilisateur);

                    return RedirectToAction("Index");
                }
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = service.getUtilisateurById(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Utilisateur utilisateur = service.getUtilisateurById(id);

            var user = await UserManager.FindByEmailAsync(utilisateur.EmailU);
            if (user != null)
            {
                var chkUser = await UserManager.DeleteAsync(user);
                service.DeleteUtilisateur(id);
            }
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
