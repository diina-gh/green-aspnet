using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Green01.App_Start;

namespace Green01.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            //this.Flash(string.Format("Soyez le bien venu"), FlashLevel.Info);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}