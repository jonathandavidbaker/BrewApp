using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DATA;

namespace UI.Controllers
{
    public class yeastsController : Controller
    {
        private brewingEntities db = new brewingEntities();

        // GET: yeasts
        public ActionResult Index()
        {
            return View(db.yeasts.ToList());
        }

        // GET: yeasts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yeast yeast = db.yeasts.Find(id);
            if (yeast == null)
            {
                return HttpNotFound();
            }
            return View(yeast);
        }

        // GET: yeasts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: yeasts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,ytype,form,amount,amount_is_weight,laboratory,product_id,min_temperature,max_temperature,flocculation,attenuation,notes,best_for,times_cultured,max_reuse,add_to_secondary,display_unit,display_scale,deleted,display,folder")] yeast yeast)
        {
            if (ModelState.IsValid)
            {
                db.yeasts.Add(yeast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yeast);
        }

        // GET: yeasts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yeast yeast = db.yeasts.Find(id);
            if (yeast == null)
            {
                return HttpNotFound();
            }
            return View(yeast);
        }

        // POST: yeasts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,ytype,form,amount,amount_is_weight,laboratory,product_id,min_temperature,max_temperature,flocculation,attenuation,notes,best_for,times_cultured,max_reuse,add_to_secondary,display_unit,display_scale,deleted,display,folder")] yeast yeast)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yeast).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yeast);
        }

        // GET: yeasts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yeast yeast = db.yeasts.Find(id);
            if (yeast == null)
            {
                return HttpNotFound();
            }
            return View(yeast);
        }

        // POST: yeasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            yeast yeast = db.yeasts.Find(id);
            db.yeasts.Remove(yeast);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
