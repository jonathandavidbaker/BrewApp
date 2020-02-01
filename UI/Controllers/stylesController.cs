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
    public class stylesController : Controller
    {
        private brewingEntities db = new brewingEntities();

        // GET: styles
        public ActionResult Index()
        {
            return View(db.styles.ToList());
        }

        // GET: styles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            style style = db.styles.Find(id);
            if (style == null)
            {
                return HttpNotFound();
            }
            return View(style);
        }

        // GET: styles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: styles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,s_type,category,category_number,style_letter,style_guide,og_min,og_max,fg_min,fg_max,ibu_min,ibu_max,color_min,color_max,abv_min,abv_max,carb_min,carb_max,notes,profile,ingredients,examples,deleted,display,folder")] style style)
        {
            if (ModelState.IsValid)
            {
                db.styles.Add(style);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(style);
        }

        // GET: styles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            style style = db.styles.Find(id);
            if (style == null)
            {
                return HttpNotFound();
            }
            return View(style);
        }

        // POST: styles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,s_type,category,category_number,style_letter,style_guide,og_min,og_max,fg_min,fg_max,ibu_min,ibu_max,color_min,color_max,abv_min,abv_max,carb_min,carb_max,notes,profile,ingredients,examples,deleted,display,folder")] style style)
        {
            if (ModelState.IsValid)
            {
                db.Entry(style).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(style);
        }

        // GET: styles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            style style = db.styles.Find(id);
            if (style == null)
            {
                return HttpNotFound();
            }
            return View(style);
        }

        // POST: styles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            style style = db.styles.Find(id);
            db.styles.Remove(style);
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
