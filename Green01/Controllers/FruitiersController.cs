using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MetierPlant.Models;
using MetierPlant.Models;

namespace Green01.Controllers
{
    //[Authorize]
    public class FruitiersController : Controller
    {
        private ServiceMetierPlants.Service1Client service = new ServiceMetierPlants.Service1Client();

        // GET: Fruitiers
        public async Task<ActionResult> Index()
        {
            return View(await service.ListFruitierAsync());
        }

        // GET: Fruitiers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fruitier fruitier = await service.getFruitierByIdAsync(id);
            if (fruitier == null)
            {
                return HttpNotFound();
            }
            return View(fruitier);
        }

        // GET: Fruitiers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fruitiers/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,designation,datePlante,Taille,Poids,Humidite,Type,DateSemanance")] Fruitier fruitier)
        {
            if (ModelState.IsValid)
            {
                service.AddFruitier(fruitier);
                return RedirectToAction("Index");
            }

            return View(fruitier);
        }

        // GET: Fruitiers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fruitier fruitier = await service.getFruitierByIdAsync(id);
            if (fruitier == null)
            {
                return HttpNotFound();
            }
            return View(fruitier);
        }

        // POST: Fruitiers/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,designation,datePlante,Taille,Poids,Humidite,Type,DateSemanance")] Fruitier fruitier)
        {
            if (ModelState.IsValid)
            {
                service.UpdateFruitier(fruitier);
                return RedirectToAction("Index");
            }
            return View(fruitier);
        }

        // GET: Fruitiers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fruitier fruitier = await service.getFruitierByIdAsync(id);
            if (fruitier == null)
            {
                return HttpNotFound();
            }
            return View(fruitier);
        }

        // POST: Fruitiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            service.DeleteFruitier(id);
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