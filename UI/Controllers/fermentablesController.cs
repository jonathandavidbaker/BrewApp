using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DATA;
using UI.Models;
using System.Dynamic;

namespace UI.Controllers
{
    public class fermentablesController : Controller
    {
        private brewingEntities db = new brewingEntities();

        // GET: fermentables
        public ActionResult Index()
        {
            return View(db.fermentables.ToList());
        }

        [HttpGet]
        public ActionResult RecipeTest()
        {
            var malts = db.fermentables.ToList();
            var maltVM = new MaltViewModel { MaltList = malts };
            var recipeVM = new RecipeViewModel { MaltList = malts };
            recipeVM.EstOG = 0;
            
            return View(recipeVM);
        }

        [HttpPost]
        public ActionResult RecipeTest(RecipeViewModel recipeVM)
        {
            //var maltYield = recipeVM.Malt.yield;
            recipeVM.EstOG = (double)(((((((recipeVM.Yield / 100) * 46) * recipeVM.Pounds) * (recipeVM.Efficiency / 100)) / recipeVM.Gallons) / 1000) + 1);
            return View("RecipeResults", recipeVM);
        }


        // GET: fermentables/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fermentable fermentable = db.fermentables.Find(id);
            if (fermentable == null)
            {
                return HttpNotFound();
            }
            return View(fermentable);
        }

        // GET: fermentables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: fermentables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,ftype,amount,yield,color,add_after_boil,origin,supplier,notes,coarse_fine_diff,moisture,diastatic_power,protein,max_in_batch,recommend_mash,is_mashed,ibu_gal_per_lb,display_unit,display_scale,deleted,display,folder")] fermentable fermentable)
        {
            if (ModelState.IsValid)
            {
                db.fermentables.Add(fermentable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fermentable);
        }

        // GET: fermentables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fermentable fermentable = db.fermentables.Find(id);
            if (fermentable == null)
            {
                return HttpNotFound();
            }
            return View(fermentable);
        }

        // POST: fermentables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,ftype,amount,yield,color,add_after_boil,origin,supplier,notes,coarse_fine_diff,moisture,diastatic_power,protein,max_in_batch,recommend_mash,is_mashed,ibu_gal_per_lb,display_unit,display_scale,deleted,display,folder")] fermentable fermentable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fermentable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fermentable);
        }

        // GET: fermentables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fermentable fermentable = db.fermentables.Find(id);
            if (fermentable == null)
            {
                return HttpNotFound();
            }
            return View(fermentable);
        }

        // POST: fermentables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fermentable fermentable = db.fermentables.Find(id);
            db.fermentables.Remove(fermentable);
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
