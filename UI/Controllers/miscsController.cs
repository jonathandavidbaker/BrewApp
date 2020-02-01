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
    public class miscsController : Controller
    {
        private brewingEntities db = new brewingEntities();

        // GET: miscs
        public ActionResult Index()
        {
            return View(db.miscs.ToList());
        }

        // GET: miscs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            misc misc = db.miscs.Find(id);
            if (misc == null)
            {
                return HttpNotFound();
            }
            return View(misc);
        }

        // GET: miscs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: miscs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,mtype,use,time,amount,amount_is_weight,use_for,notes,display_unit,display_scale,deleted,display,folder")] misc misc)
        {
            if (ModelState.IsValid)
            {
                db.miscs.Add(misc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(misc);
        }

        // GET: miscs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            misc misc = db.miscs.Find(id);
            if (misc == null)
            {
                return HttpNotFound();
            }
            return View(misc);
        }

        // POST: miscs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,mtype,use,time,amount,amount_is_weight,use_for,notes,display_unit,display_scale,deleted,display,folder")] misc misc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(misc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(misc);
        }

        // GET: miscs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            misc misc = db.miscs.Find(id);
            if (misc == null)
            {
                return HttpNotFound();
            }
            return View(misc);
        }

        // POST: miscs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            misc misc = db.miscs.Find(id);
            db.miscs.Remove(misc);
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
