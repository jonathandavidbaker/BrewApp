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

namespace UI.Controllers
{
    public class hopsController : Controller
    {
        private brewingEntities db = new brewingEntities();

        // GET: hops
        public ActionResult Index()
        {
            return View(db.hops.ToList());
        }

        public ActionResult HopList()
        {
            var hops = db.hops.ToList();
            var viewModel = new HopViewModel { HopList = hops };

            return View(viewModel);
        }

        // GET: hops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hop hop = db.hops.Find(id);
            if (hop == null)
            {
                return HttpNotFound();
            }
            return View(hop);
        }

        // GET: hops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: hops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,alpha,amount,use,time,notes,htype,form,beta,hsi,origin,substitutes,humulene,caryophyllene,cohumulone,myrcene,display_unit,display_scale,deleted,display,folder")] hop hop)
        {
            if (ModelState.IsValid)
            {
                db.hops.Add(hop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hop);
        }

        // GET: hops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hop hop = db.hops.Find(id);
            if (hop == null)
            {
                return HttpNotFound();
            }
            return View(hop);
        }

        // POST: hops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,alpha,amount,use,time,notes,htype,form,beta,hsi,origin,substitutes,humulene,caryophyllene,cohumulone,myrcene,display_unit,display_scale,deleted,display,folder")] hop hop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hop);
        }

        // GET: hops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hop hop = db.hops.Find(id);
            if (hop == null)
            {
                return HttpNotFound();
            }
            return View(hop);
        }

        // POST: hops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hop hop = db.hops.Find(id);
            db.hops.Remove(hop);
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
