﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DancerWeb.Models;
using System.Web.UI.WebControls;


namespace DancerWeb.Controllers
{
    public class DancersController : Controller
    {
        private DanceDbContext db = new DanceDbContext();

        public HashSet<string> Online = new HashSet<string>();
        // GET: Dancers
        public ActionResult Index()
        {
            return View(db.Dancers.ToList());
        }

        // GET: Dancers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dancers dancers = db.Dancers.Find(id);
            if (dancers == null)
            {
                return HttpNotFound();
            }
            return View(dancers);
        }

        // GET: Dancers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dancers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,Phone,StudioAddress,StudioName,City,Email,Password")] Dancers dancers)
        {
            if (ModelState.IsValid)
            {
                db.Dancers.Add(dancers);
                db.SaveChanges();
                return RedirectToRoute("MyRoute");
            }

            return View(dancers);
        }

        // GET: Dancers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dancers dancers = db.Dancers.Find(id);
            if (dancers == null)
            {
                return HttpNotFound();
            }
            return View(dancers);
        }

        // POST: Dancers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age,Phone,StudioAddress,StudioName,City,Email,Password")] Dancers dancers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dancers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dancers);
        }

        // GET: Dancers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dancers dancers = db.Dancers.Find(id);
            if (dancers == null)
            {
                return HttpNotFound();
            }
            return View(dancers);
        }

        // POST: Dancers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dancers dancers = db.Dancers.Find(id);
            db.Dancers.Remove(dancers);
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

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Dancers usrAccount)
        {
            using (DanceDbContext db = new DanceDbContext())
            {
                var usr = db.Dancers.Where(u => u.Id == usrAccount.Id && u.Password == usrAccount.Password);
                if (usr != null)
                {
                    Online.Add( usrAccount.Email.ToString());
                    Session["UserID"] = usrAccount.Id.ToString();
                    Session["UserMail"] = usrAccount.Email.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else { ModelState.AddModelError("","Mail or Password is wrong.");}

            }

            return View();

        }

        public ActionResult LoggedIn()
        {
            if (Session["UserMail"] != null)
            {
                
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
      

    }
}
