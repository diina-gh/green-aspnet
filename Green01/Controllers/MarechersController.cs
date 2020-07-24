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
using MetierPlant.Models;

namespace Green01.Controllers
{
    [Authorize]
    public class MarechersController : Controller
    {
        private ServiceMetierPlants.Service1Client service = new ServiceMetierPlants.Service1Client();

        // GET: Marechers
        public async Task<ActionResult> Index()
        {
            return View(await service.ListMarecherAsync());
        }

        // GET: Marechers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marecher marecher = await service.getMarecherByIdAsync(id);
            if (marecher == null)
            {
                return HttpNotFound();
            }
            return View(marecher);
        }

        // GET: Marechers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marechers/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,designation,datePlante,Taille,Poids,Humidite,Semanance,Periode")] Marecher marecher)
        {
            if (ModelState.IsValid)
            {
                service.AddMarecher(marecher);
                return RedirectToAction("Index");
            }

            return View(marecher);
        }

        // GET: Marechers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marecher marecher = await service.getMarecherByIdAsync(id);
            if (marecher == null)
            {
                return HttpNotFound();
            }
            return View(marecher);
        }

        // POST: Marechers/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,designation,datePlante,Taille,Poids,Humidite,Semanance,Periode")] Marecher marecher)
        {
            if (ModelState.IsValid)
            {
                service.UpdateMarecher(marecher);
                return RedirectToAction("Index");
            }
            return View(marecher);
        }

        // GET: Marechers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marecher marecher = await service.getMarecherByIdAsync(id);
            if (marecher == null)
            {
                return HttpNotFound();
            }
            return View(marecher);
        }

        // POST: Marechers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            service.DeleteMarecher(id);
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
