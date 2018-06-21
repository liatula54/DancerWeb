using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DancerWeb.Models;

namespace DancerWeb.Controllers
{
    public class GroupDancersController : Controller
    {
        private DanceDbContext db = new DanceDbContext();

        // GET: GroupDancers
        public ActionResult Index()
        {
            return View(db.GroupDancers.ToList());
        }

        // GET: GroupDancers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupDancers groupDancers = db.GroupDancers.Find(id);
            if (groupDancers == null)
            {
                return HttpNotFound();
            }
            return View(groupDancers);
        }

        // GET: GroupDancers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupDancers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] GroupDancers groupDancers)
        {
            if (ModelState.IsValid)
            {
                db.GroupDancers.Add(groupDancers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupDancers);
        }

        // GET: GroupDancers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupDancers groupDancers = db.GroupDancers.Find(id);
            if (groupDancers == null)
            {
                return HttpNotFound();
            }
            return View(groupDancers);
        }

        // POST: GroupDancers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] GroupDancers groupDancers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupDancers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupDancers);
        }

        // GET: GroupDancers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupDancers groupDancers = db.GroupDancers.Find(id);
            if (groupDancers == null)
            {
                return HttpNotFound();
            }
            return View(groupDancers);
        }

        // POST: GroupDancers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupDancers groupDancers = db.GroupDancers.Find(id);
            db.GroupDancers.Remove(groupDancers);
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
